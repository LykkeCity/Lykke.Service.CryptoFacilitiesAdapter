using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Common.Log;
using Lykke.Common.Log;
using Lykke.СryptoFacilities.WebSockets.Messages;
using Newtonsoft.Json.Linq;

namespace Lykke.СryptoFacilities.WebSockets
{
    public class PrivateCryptoFacilitiesConnection<TSnapshot, TPayload> : WebSocketConnection
    {
        private readonly string _feed;
        private readonly string _apiPrivateKey;
        private readonly string _apiPublicKey;
        private readonly Func<TSnapshot, Task> _snapshotHandlerAction;
        private readonly Func<TPayload, Task> _payloadHandlerAction;
 
        private bool _signedMessage;
        private bool _subscribed;

        private ILog _log;
        
        public PrivateCryptoFacilitiesConnection(
            string baseUri,
            string feed,
            Func<TSnapshot, Task> snapshotHandlerAction,
            Func<TPayload, Task> payloadHandlerAction,
            string apiPrivateKey,
            string apiPublicKey,
            TimeSpan timeout,
            ILogFactory logFactory) : base(baseUri, timeout, logFactory)
        {
            _feed = feed;
            _snapshotHandlerAction = snapshotHandlerAction;
            _payloadHandlerAction = payloadHandlerAction;
            _apiPrivateKey = apiPrivateKey;
            _apiPublicKey = apiPublicKey;

            _log = logFactory.CreateLog(this);

            _signedMessage = false;
            _subscribed = false;
        }

        protected override async Task HandleNewMessageAsync(string message)
        {
            var jToken = JToken.Parse(message);

            var type = jToken["event"]?.Value<string>();

            if (string.IsNullOrWhiteSpace(type))
            {
                var feed = jToken["feed"]?.Value<string>();
                    
                if (!string.IsNullOrWhiteSpace(feed))
                {
                    if (feed == _feed)
                    {
                        await HandlePayloadAsync(jToken);
                    }
                    else if (feed == $"{_feed}_snapshot")
                    {
                        await HandleSnapshotAsync(jToken);
                    }
                    else
                    {
                        _log.Error($"Unknown feed for message: {jToken}");
                    }
                }
                else
                {
                    _log.Error($"Unknown type for message: {jToken}");
                }
            }
            else
            {
                switch (type)
                {
                    case "info" :
                        break;
                    case "challenge" :
                        await HandleChallengeMessageAsync(jToken);
                        break;
                    case "subscribed":
                        HandleSubscribeMessage(jToken);
                        break;
                    case "error":
                        HandleErrorMessage(jToken);
                        break;
                    default:
                        _log.Warning($"Unknown type of message: {jToken}.");
                        break;
                }
            }
        }

        private async Task HandleSnapshotAsync(JToken jToken)
        {
            if (_snapshotHandlerAction != null)
                await _snapshotHandlerAction.Invoke(jToken.ToObject<TSnapshot>());
        }

        private async Task HandlePayloadAsync(JToken jToken)
        {
            if (_payloadHandlerAction != null)
                await _payloadHandlerAction.Invoke(jToken.ToObject<TPayload>());
        }

        private void HandleErrorMessage(JToken jToken)
        {
            if (!_subscribed)
            {
                _log.Critical(jToken.ToString());
            }
            else
            {
                _log.Error(jToken.ToString());
            }
        }

        private void HandleSubscribeMessage(JToken jToken)
        {
            _subscribed = true;
            
            _log.Info("Subscribed to feed.");
        }

        private async Task HandleChallengeMessageAsync(JToken jToken)
        {
            if (_signedMessage)
            {
                _log.Warning("Message signing request received but no need.");
                return;
            }
            
            var result = jToken.ToObject<ChallengeMessage>();

            await SendMessageAsync(new SubscribeRequest(_feed, _apiPublicKey, result.Message, SignChallenge(result.Message)));
        }

        protected override Task Connected()
        {
            return RequestChallenge();
        }

        private Task RequestChallenge()
        {
            return SendMessageAsync(new RequestChallengeMessage(_apiPublicKey));
        }

        protected override Task Disconnected()
        {
            _signedMessage = false;
            _subscribed = false;

            return Task.CompletedTask;
        }
        
        private string SignChallenge(string challenge)
        {
            //Step 1: hash the result of step 1 with SHA256
            var hash256 = new SHA256Managed();
            var hash = hash256.ComputeHash(Encoding.UTF8.GetBytes(challenge));

            //step 2: base64 decode apiPrivateKey
            var secretDecoded = (System.Convert.FromBase64String(_apiPrivateKey));

            //step 3: use result of step 3 to hash the result of step 2 with HMAC-SHA512
            var hmacsha512 = new HMACSHA512(secretDecoded);
            var hash2 = hmacsha512.ComputeHash(hash);

            //step 4: base64 encode the result of step 4 and return
            return System.Convert.ToBase64String(hash2);
        }
    }
}
