using System;
using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.Models.Request
{
    public class GetOrderFillsRequestUrl : BaseRequestUrl
    {
        /// <summary>
        /// If not provided, returns the last 100 fills in any futures contract. If provided, returns the 100 entries before LastFillTime.
        /// </summary>
        [JsonProperty("lastFillTime")]
        public DateTime? LastFillTime { set; get; }
    }
}
