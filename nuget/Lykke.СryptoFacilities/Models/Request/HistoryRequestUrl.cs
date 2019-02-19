using System;
using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Request
{
    /// <summary>
    /// Describes request for history list.
    /// </summary>
    public class HistoryRequestUrl : BaseRequestUrl
    {
        /// <summary>
        /// The symbol of the Futures.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { set; get; }
        
        /// <summary>
        /// Returns 100 trades from the specified lastTime value.
        /// </summary>
        [JsonProperty("lastTime")]
        public DateTime? LastTime { set; get; }
    }
}
