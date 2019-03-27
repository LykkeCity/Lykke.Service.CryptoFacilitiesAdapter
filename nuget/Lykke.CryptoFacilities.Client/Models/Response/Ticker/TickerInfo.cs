using System;
using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.Models.Response.Ticker
{
    /// <summary>
    /// An object  containing info for a particular instrument.
    /// </summary>
    public class TickerInfo
    {
        /// <summary>
        /// For Futures: Currently can be 'week', 'month' or 'quarter'. Other tags may be added without notice.
        /// For indices: Not returned because N/A.
        /// </summary>
        [JsonProperty("tag")]
        public string Tag { get; set; }
        
        /// <summary>
        /// For Futures: The currency pair of the instrument.
        /// For indices: Not returned because N/A.
        /// </summary>
        [JsonProperty("pair")]
        public string Pair { get; set; }
        
        /// <summary>
        /// The symbol of the Futures or index.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        
        /// <summary>
        /// For Futures: The price to which Crypto Facilities currently marks the Futures for margining purposes.
        /// For indices: Not returned because N/A
        /// </summary>
        [JsonProperty("markPrice")]
        public decimal? MarkPrice { get; set; }
        
        /// <summary>
        /// For Futures: The price of the current best bid
        /// For indices: Not returned because N/A
        /// </summary>
        [JsonProperty("bid")]
        public decimal? Bid { get; set; }
        
        /// <summary>
        /// For Futures: The size of the current best bid.
        /// For indices: Not returned because N/A.
        /// </summary>
        [JsonProperty("bidSize")]
        public decimal? BidSize { get; set; }
        
        /// <summary>
        /// For Futures: The price of the current best ask.
        /// For indices: Not returned because N/A.
        /// </summary>
        [JsonProperty("ask")]
        public decimal? Ask { get; set; }
        
        /// <summary>
        /// For Futures: The size of the current best ask.
        /// For indices: Not returned because N/A.
        /// </summary>
        [JsonProperty("askSize")]
        public decimal? AskSize { get; set; }
        
        /// <summary>
        /// For Futures: The sum of the sizes of all fills observed in the last 24 hours.
        /// For indices: Not returned because N/A.
        /// </summary>
        [JsonProperty("vol24h")]
        public decimal? Volume24h { get; set; }
        
        /// <summary>
        /// For Futures: The current open interest of the instrument.
        /// For indices: Not returned because N/A.
        /// </summary>
        [JsonProperty("openInterest")]
        public decimal? OpenInterest { get; set; }
        
        /// <summary>
        /// For Futures: The price of the fill observed 24 hours ago.
        /// For spot price indices: The value calculated 24 hours ago.
        /// For volatility indices: Not returned because N/A.
        /// </summary>
        [JsonProperty("open24h")]
        public decimal? Open24h { get; set; }
        
        /// <summary>
        /// For Futures: The price of the last fill.
        /// For indices: The last calculated value. For spot price indices, this is a U.S. dollar value. For the volatility index, this is a percentage value.
        /// </summary>
        [JsonProperty("last")]
        public decimal Last { get; set; }
        
        /// <summary>
        /// The date and time at which Last was observed
        /// </summary>
        [JsonProperty("lastTime")]
        public DateTime LastTime { get; set; }
        
        /// <summary>
        /// For Futures: The size of the last fill.
        /// For indices: Not returned because N/A.
        /// </summary>
        [JsonProperty("lastSize")]
        public long? LastSize { get; set; }
        
        /// <summary>
        /// True if the market is suspended, false otherwise.
        /// </summary>
        [JsonProperty("suspended")]
        public bool Suspended { get; set; }
    }
}
