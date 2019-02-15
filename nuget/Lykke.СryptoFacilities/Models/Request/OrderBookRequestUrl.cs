using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Request
{
    public class OrderBookRequestUrl : BaseRequestUrl
    {
        /// <summary>
        /// The symbol of the Futures.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { set; get; }
    }
}
