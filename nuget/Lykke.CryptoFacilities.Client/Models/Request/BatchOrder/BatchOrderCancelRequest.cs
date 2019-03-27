using Lykke.CryptoFacilities.Models.Common;
using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.Models.Request.BatchOrder
{
    public class BatchOrderCancelRequest : BatchOrderRequest
    {
        /// <summary>
        /// Request type.
        /// </summary>
        [JsonProperty("order")]
        public override BatchOrderType RequestType => BatchOrderType.Cancel;
        
        /// <summary>
        /// The unique identifier of the order to be cancelled. Should be set only if RequestType is Cancel.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { set; get; }
    }
}
