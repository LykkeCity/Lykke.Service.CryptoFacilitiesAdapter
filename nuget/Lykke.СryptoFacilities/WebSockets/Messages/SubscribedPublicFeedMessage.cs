using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.WebSockets.Messages
{
    public class SubscribedPublicFeedMessage
    {
        [JsonProperty("event")]
        public string Event { set; get; }

        [JsonProperty("feed")]
        public string Feed { set; get; }

        public string ProductId => _productIds.Length == 1 ? _productIds[0] : null;

        [JsonProperty("product_ids")]
        public string[] _productIds { set; private get; }
    }
}
