using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Lykke.СryptoFacilities.Models.Request
{
    public class CancelOrderRequestUrl : BaseRequestUrl
    {
        /// <summary>
        /// The unique identifier of the order to be cancelled.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { set; get; }
        
        /// <summary>
        /// The client unique identifier of the order to be cancelled.
        /// </summary>
        [JsonProperty("cliOrdId")]
        public string ClientOrderId { set; get; }
    }
}
