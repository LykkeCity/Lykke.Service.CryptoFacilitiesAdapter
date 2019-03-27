using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.Models.Response.GetAccountInfo
{
    /// <summary>
    /// Margin requirements.
    /// </summary>
    public class MarginRequirements
    {
        /// <summary>
        /// The initial margin requirement of the account
        /// </summary>
        [JsonProperty("im")]
        public double InitialMargin { get; set; }

        /// <summary>
        /// The maintenance margin requirement of the account
        /// </summary>
        [JsonProperty("mm")]
        public double MaintenanceMargin { get; set; }

        /// <summary>
        /// The liquidation threshold of the account
        /// </summary>
        [JsonProperty("lt")]
        public double LiquidationThreshold { get; set; }

        /// <summary>
        /// The termination threshold of the account
        /// </summary>
        [JsonProperty("tt")]
        public double TerminationThreshold { get; set; }
    }
}
