using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Response.GetAccountInfo
{
    /// <summary>
    /// Account auxiliary info.
    /// </summary>
    public class AuxiliaryInfo
    {
        /// <summary>
        /// The portfolio value of the account, in currency
        /// </summary>
        [JsonProperty("pv")]
        public decimal PortfolioValue { get; set; }

        /// <summary>
        /// The PnL of current open positions of the account, in currency.
        /// </summary>
        [JsonProperty("pnl")]
        public decimal PnL { get; set; }

        /// <summary>
        /// The available funds of the account, in currency
        /// </summary>
        [JsonProperty("af")]
        public decimal AvailableFunds { get; set; }
    }
}
