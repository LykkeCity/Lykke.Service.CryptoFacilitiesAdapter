using System.Collections.Generic;
using Lykke.СryptoFacilities.Models.Common;
using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Response
{
    public class GetAccountInfoResponse : BaseResponse
    {
        /// <summary>
        /// An object containing structures with account-related information for all margin and cash accounts.
        /// </summary>
        [JsonProperty("accounts")]
        public AccountsInfo Accounts { set; get; }
    }
    
    public class AccountsInfo
    {
        [JsonProperty("fi_xbtusd")]
        public Account BTCUSD { get; set; }

        [JsonProperty("cash")]
        public Account Cash { get; set; }

        [JsonProperty("fv_xrpxbt")]
        public Account XRPBTC { get; set; }

        [JsonProperty("fi_xrpusd")]
        public Account XRPUSD { get; set; }

        [JsonProperty("fi_ethusd")]
        public Account ETHUSD { get; set; }

        [JsonProperty("fi_ltcusd")]
        public Account LTCUSD { get; set; }

        [JsonProperty("fi_bchusd")]
        public Account BCHUSD { get; set; }

        public class Account
        {
            /// <summary>
            /// The type of the account.
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }
            
            /// <summary>
            /// An object containing auxiliary account information. Returned only for margin accounts.
            /// </summary>
            [JsonProperty("auxiliary")]
            public AuxiliaryInfo Auxiliary { get; set; }
            
            /// <summary>
            /// An object containing the account’s margin requirements. Returned only for margin accounts.
            /// </summary>
            [JsonProperty("marginRequirements")]
            public MarginRequirements MarginRequirements { get; set; }
            
            /// <summary>
            /// An object containing the account’s margin trigger. Returned only for margin accounts.
            /// </summary>
            [JsonProperty("triggerEstimates")]
            public TriggerEstimates TriggerEstimates { get; set; }
            
            /// <summary>
            /// An object containing account balances.
            /// </summary>
            [JsonProperty("balances")]
            public Dictionary<string, decimal> Balances { get; set; }
        }

        public class AuxiliaryInfo
        {
            [JsonProperty("usd")]
            public double Usd { get; set; }

            /// <summary>
            /// The portfolio value of the account, in currency
            /// </summary>
            [JsonProperty("pv")]
            public double PortfolioValue { get; set; }

            /// <summary>
            /// The PnL of current open positions of the account, in currency.
            /// </summary>
            [JsonProperty("pnl")]
            public double PnL { get; set; }

            /// <summary>
            /// The available funds of the account, in currency
            /// </summary>
            [JsonProperty("af")]
            public double AvailableFunds { get; set; }

            [JsonProperty("funding")]
            public double Funding { get; set; }
        }

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

        public class TriggerEstimates
        {
            /// <summary>
            /// The approximate spot price of the underlying at which the account will reach its initial margin requirement
            /// </summary>
            [JsonProperty("im")]
            public double PriceForInitialMargin { get; set; }

            /// <summary>
            /// The approximate spot price of the underlying at which the account will reach its maintenance margin requirement
            /// </summary>
            [JsonProperty("mm")]
            public double PriceMaintenanceMargin { get; set; }

            /// <summary>
            /// The approximate spot price of the underlying at which the account will reach its liquidation threshold
            /// </summary>
            [JsonProperty("lt")]
            public double PriceLiquidationThreshold { get; set; }

            /// <summary>
            /// The approximate spot price of the underlying at which the account will reach its termination threshold
            /// </summary>
            [JsonProperty("tt")]
            public double PriceTerminationThreshold { get; set; }
        }
    }
}
