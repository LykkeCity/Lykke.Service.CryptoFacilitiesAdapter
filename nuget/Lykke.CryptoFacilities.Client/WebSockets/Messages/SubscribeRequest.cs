using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.WebSockets.Messages
{
    public class SubscribeRequest : IRequest
    {
        public SubscribeRequest(string feed, IEnumerable<string> products)
        {
            Feed = feed;
            Products = products;
        }

        public SubscribeRequest(string feed, string apiKey, string originalChallenge, string signedChallenge)
        {
            Feed = feed;
            ApiKey = apiKey;
            OriginalChallenge = originalChallenge;
            SignedChallenge = signedChallenge;
        }
        
        [JsonProperty("event")]
        public string Event { get; private set; } = "subscribe";

        [JsonProperty("feed")]
        public string Feed { get; private set; }

        [JsonProperty("product_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Products { get; private set; }
        
        [JsonProperty("api_key", NullValueHandling = NullValueHandling.Ignore)]
        public string ApiKey { get; private set; }

        [JsonProperty("original_challenge", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalChallenge { get; private set; }

        [JsonProperty("signed_challenge", NullValueHandling = NullValueHandling.Ignore)]
        public string SignedChallenge { get; private set; }
    }
}
