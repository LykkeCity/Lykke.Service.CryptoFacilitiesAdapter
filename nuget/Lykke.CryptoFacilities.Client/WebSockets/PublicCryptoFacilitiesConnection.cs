using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Common.Log;
using Lykke.Common.Log;
using Lykke.CryptoFacilities.WebSockets.Messages;
using Newtonsoft.Json.Linq;

namespace Lykke.CryptoFacilities.WebSockets
{
    public class PublicCryptoFacilitiesConnection<TSnapshot, TPayload> : WebSocketConnection
    {
        private readonly string _feed;
        private readonly Func<TSnapshot, Task> _snapshotHandlerAction;
        private readonly Func<TPayload, Task> _payloadHandlerAction;
        private readonly IEnumerable<string> _products;

        private ConcurrentDictionary<string, bool> _productsSubscribed;

        private ILog _log;
        
        public PublicCryptoFacilitiesConnection(
            string baseUri,
            string feed,
            IEnumerable<string> products,
            Func<TSnapshot, Task> snapshotHandlerAction,
            Func<TPayload, Task> payloadHandlerAction,
            TimeSpan timeout,
            ILogFactory logFactory) : base(baseUri, timeout, logFactory)
        {
            _feed = feed;
            _products = products;
            _snapshotHandlerAction = snapshotHandlerAction;
            _payloadHandlerAction = payloadHandlerAction;

            _productsSubscribed = new ConcurrentDictionary<string, bool>(_products.ToDictionary(x => x, x => false));

            _log = logFactory.CreateLog(this);
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
            if (_productsSubscribed.Any(x => x.Value == false))
            {
                _log.Critical($"Could not subscribe to '{_feed}'.");
            }
            else
            {
                _log.Error(jToken.ToString());
            }
        }
        
        private void HandleSubscribeMessage(JToken jToken)
        {
            var message = jToken.ToObject<SubscribedPublicFeedMessage>();

            if (_productsSubscribed.ContainsKeyIgnoreCase(message.ProductId, out var correctKey))
            {
                if (_productsSubscribed[correctKey])
                {
                    _log.Warning($"Already subscribed to '{_feed}.{correctKey}'.");
                }
                else
                {
                    _productsSubscribed[correctKey] = true;
            
                    _log.Info($"Subscribed to '{_feed}.{correctKey}'.");
                }
            }
            else
            {
                _log.Warning($"Haven't subscribed to '{_feed}.{message.ProductId}' but received subscription confirmation.");
            }
        }

        protected override async Task Connected()
        {
            await SendMessageAsync(new SubscribeRequest(_feed, _products));
        }

        protected override Task Disconnected()
        {
            foreach (var product in _products)
            {
                _productsSubscribed[product] = false;
            }

            return Task.CompletedTask;
        }
    }
}
