using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.Models.Response.Ticker
{
    /// <summary>
    /// Response wrapper.
    /// </summary>
    public class TickerResponse : BaseResponse
    {
        /// <summary>
        /// An array containing objects for each available instrument, see below. The list is in no particular order.
        /// </summary>
        [JsonProperty("tickers")]
        public TickerInfo[] Tickers { get; set; }
    }
}
