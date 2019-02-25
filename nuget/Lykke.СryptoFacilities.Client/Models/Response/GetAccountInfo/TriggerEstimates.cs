using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Response.GetAccountInfo
{
    /// <summary>
    /// Trigger estimates.
    /// </summary>
    public class TriggerEstimates
    {
        /// <summary>
        /// The approximate spot price of the underlying at which the account will reach its initial margin requirement
        /// </summary>
        [JsonProperty("im")]
        public decimal PriceForInitialMargin { get; set; }

        /// <summary>
        /// The approximate spot price of the underlying at which the account will reach its maintenance margin requirement
        /// </summary>
        [JsonProperty("mm")]
        public decimal PriceMaintenanceMargin { get; set; }

        /// <summary>
        /// The approximate spot price of the underlying at which the account will reach its liquidation threshold
        /// </summary>
        [JsonProperty("lt")]
        public decimal PriceLiquidationThreshold { get; set; }

        /// <summary>
        /// The approximate spot price of the underlying at which the account will reach its termination threshold
        /// </summary>
        [JsonProperty("tt")]
        public decimal PriceTerminationThreshold { get; set; }
    }
}
