using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.Models.Request
{
    public class CancelAllOrdersAfterRequestUrl : BaseRequestUrl
    {
        /// <summary>
        /// The timeout specified in seconds.
        /// </summary>
        [JsonProperty("timeout")]
        public long Timeout { set; get; }
    }
}
