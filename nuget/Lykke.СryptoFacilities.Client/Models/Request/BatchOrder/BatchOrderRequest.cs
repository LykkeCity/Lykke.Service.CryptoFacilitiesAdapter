using Lykke.СryptoFacilities.Models.Common;
using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Request.BatchOrder
{
    public abstract class BatchOrderRequest
    {
        /// <summary>
        /// Request type.
        /// </summary>
        [JsonProperty("order")]
        public virtual BatchOrderType RequestType { set; get; }
        
        /// <summary>
        /// The order identity that is specified from the user. It must be globally unique.
        /// </summary>
        [JsonProperty("cliOrdId")]
        public string ClientOrderId { set; get; }
    }
}
