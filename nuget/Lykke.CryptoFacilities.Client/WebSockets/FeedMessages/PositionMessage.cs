using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.WebSockets.FeedMessages
{
    public class PositionMessage
    {
        [JsonProperty("instrument")]
        public string Instrument { get; set; }

        [JsonProperty("balance")]
        public decimal Balance { get; set; }

        [JsonProperty("entry_price")]
        public decimal EntryPrice { get; set; }

        [JsonProperty("mark_price")]
        public decimal MarkPrice { get; set; }

        [JsonProperty("index_price")]
        public decimal IndexPrice { get; set; }

        [JsonProperty("pnl")]
        public decimal Pnl { get; set; }

        [JsonProperty("liquidation_threshold")]
        public decimal LiquidationThreshold { get; set; }

        [JsonProperty("return_on_equity")]
        public decimal ReturnOnEquity { get; set; }

        [JsonProperty("effective_leverage")]
        public decimal EffectiveLeverage { get; set; }
    }
}
