using System;
using System.Collections.Generic;
using Common;
using Newtonsoft.Json;

namespace Lykke.СryptoFacilities
{
    public class BaseResponce
    {
        public string Result { get; set; }
        public DateTime ServerTime { get; set; }
        public string Error { get; set; }

        public override string ToString()
        {
            return this.ToJson();
        }
    }

    public class TickerResponce : BaseResponce
    {
        public List<TickerInfo> Tickers { get; set; }
    }

    public class TickerInfo
    {
        public string Tag { get; set; }
        public string Pair { get; set; }
        public string Symbol { get; set; }
        public decimal MarkPrice { get; set; }
        public decimal Bid { get; set; }
        public decimal BidSize { get; set; }
        public decimal Ask { get; set; }
        public decimal AskSize { get; set; }
        public decimal Vol24h { get; set; }
        public decimal OpenInterest { get; set; }
        public decimal Open24h { get; set; }
        public decimal Last { get; set; }
        public DateTime LastTime { get; set; }
        public decimal LastSize { get; set; }
        public bool Suspended { get; set; }
        public decimal FundingRate { get; set; }
        public decimal FundingRatePrediction { get; set; }
    }

    public class OpenPositionsResponce : BaseResponce
    {
        public List<OpenPosition> OpenPositions { get; set; }
    }

    public class OpenPosition
    {
        public SideType Side { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public DateTime FillTime { get; set; }
        public decimal Size { get; set; }
    }

    public enum SideType
    {
        Unknown,
        Long,
        Short
    }

    public class AccountInfoResponce : BaseResponce
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
            public AccountType Type { get; set; }
            public AuxiliaryInfo Auxiliary { get; set; }
            public MarginRequirements MarginRequirements { get; set; }
            public TriggerEstimates TriggerEstimates { get; set; }
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

        public enum AccountType
        {
            CashAccount,
            MarginAccount
        }
    }
}
