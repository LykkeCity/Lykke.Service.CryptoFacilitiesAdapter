using System;
using JetBrains.Annotations;
using Lykke.CryptoFacilities.Models.Common;
using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.Models.Response.History
{
    /// <summary>
    /// History record.
    /// </summary>
    [UsedImplicitly]
    public class HistoryRecord
    {
        /// <summary>
        /// The date and time of a trade or an index computation.
        /// For Futures: The date and time of a trade. Data is not aggregated.
        /// For indices: The date and time of an index computation. For real-time indices, data is aggregated to the last computation of each full hour. For reference rates, data is not aggregated.
        /// </summary>
        [JsonProperty("time")]
        public DateTime Time { set; get; }
        
        /// <summary>
        /// For Futures: A continuous index starting at 1 for the first fill in a Futures contract maturity.
        /// For indices: Not returned because N/A.
        /// </summary>
        [JsonProperty("trade_id")]
        public long TradeId { set; get; }
        
        /// <summary>
        /// For Futures: The price of a fill.
        /// For indices: The calculated value.
        /// </summary>
        [JsonProperty("price")]
        public decimal Price { set; get; }
        
        /// <summary>
        /// For Futures: The size of a fill.
        /// For indices: Not returned because N/A.
        /// </summary>
        [JsonProperty("size")]
        public decimal? Size { set; get; }
        
        /// <summary>
        /// The classification of the taker side in the matched trade: "buy" if the taker is a buyer, "sell" if the taker is a seller.
        /// </summary>
        [JsonProperty("side")]
        public Side Side { set; get; }
        
        /// <summary>
        /// The classification of the matched trade in an orderbook: "fill" if it is a normal buyer and seller, "liquidation" if it is a result of a user being liquidated from their position, "assignment" if the fill is the result of a users position being assigned to a marketmaker, or "termination" if it is a result of a user being terminated.
        /// </summary>
        [JsonProperty("type")]
        public string Type { set; get; }
    }
}
