using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.Models.Response.GetAccountInfo
{
    /// <summary>
    /// Object with all the accounts.
    /// </summary>
    public class AccountsInfo
    {
        /// <summary>
        /// BTCUSD account.
        /// </summary>
        [JsonProperty(Accounts.BTCUSD)]
        public Account BTCUSD { get; set; }

        /// <summary>
        /// Cash account.
        /// </summary>
        [JsonProperty(Accounts.Cash)]
        public Account Cash { get; set; }
        
        /// <summary>
        /// XRPBTC account.
        /// </summary>
        [JsonProperty(Accounts.XRPBTC)]
        public Account XRPBTC { get; set; }

        /// <summary>
        /// XRPUSD account.
        /// </summary>
        [JsonProperty(Accounts.XRPUSD)]
        public Account XRPUSD { get; set; }

        /// <summary>
        /// ETHUSD account.
        /// </summary>
        [JsonProperty(Accounts.ETHUSD)]
        public Account ETHUSD { get; set; }

        /// <summary>
        /// LTCUSD account.
        /// </summary>
        [JsonProperty(Accounts.LTCUSD)]
        public Account LTCUSD { get; set; }

        /// <summary>
        /// BCHUSD account.
        /// </summary>
        [JsonProperty(Accounts.BCHUSD)]
        public Account BCHUSD { get; set; }
    }
}
