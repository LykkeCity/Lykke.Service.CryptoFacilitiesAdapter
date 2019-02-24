using System.Linq;
using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.WebSockets.Messages
{
    public class SubscribedPublicFeedMessage
    {
        [JsonProperty("event")]
        public string Event { set; get; }

        [JsonProperty("feed")]
        public string Feed { set; get; }

        public string ProductId => ProductIds.SingleOrDefault();

        [JsonProperty("product_ids")]
        public string[] ProductIds { set; private get; }
    }
}
