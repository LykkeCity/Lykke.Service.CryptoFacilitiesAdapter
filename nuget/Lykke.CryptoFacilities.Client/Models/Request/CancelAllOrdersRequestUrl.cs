using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.Models.Request
{
    public class CancelAllOrdersRequestUrl : BaseRequestUrl
    {
        /// <summary>
        /// A margin account or future product to cancel all open orders.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { set; get; }
    }
}
