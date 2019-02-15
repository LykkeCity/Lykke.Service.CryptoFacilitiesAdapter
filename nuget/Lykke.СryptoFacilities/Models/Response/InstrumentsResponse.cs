using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Response
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class InstrumentsResponse : BaseResponse
    {
        /// <summary>
        /// An array containing objects for each available instrument. The list is in no particular order.
        /// </summary>
        public Instrument[] Instruments { set; get; }
    }

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class Instrument
    {
        /// <summary>
        /// The symbol of the Futures or index.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { set; get; }
        
        /// <summary>
        /// The symbol of the Futures or index.
        /// </summary>
        [JsonProperty("type")]
        public string Type { set; get; }
        
        /// <summary>
        /// For Futures: The underlying of the Futures.
        /// For indices: Not returned because N/A.
        /// </summary>
        [JsonProperty("underlying")]
        public string Underlying { set; get; }
        
        /// <summary>
        /// For Futures: The date and time at which the Futures stops trading.
        /// For indices: Not returned because N/A.
        /// </summary>
        [JsonProperty("lastTradingTime")]
        public DateTime? LastTradingTime { set; get; }
        
        /// <summary>
        /// For Futures: The tick size increment of the Futures.
        /// For indices: Not returned because N/A.
        /// </summary>
        [JsonProperty("tickSize")]
        public decimal? TickSize { set; get; }
        
        /// <summary>
        /// For Futures: For Futures: The contract size of the Futures.
        /// For indices: Not returned because N/A.
        /// </summary>
        [JsonProperty("contractSize")]
        public long? ContractSize { set; get; }
        
        /// <summary>
        /// True if the instrument can be traded, false otherwise.
        /// </summary>
        [JsonProperty("tradeable")]
        public bool Tradeable { set; get; }
        
        /// <summary>
        /// For Futures: A list containing the margin schedules.
        /// For indices: Not returned because N/A.
        /// </summary>
        [JsonProperty("marginLevels")]
        public InstrumentMarginLevel[] MarginLevels { set; get; }
    }

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class InstrumentMarginLevel
    {
        /// <summary>
        /// For Futures: The lower limit of the number of contracts that this margin level applies.
        /// </summary>
        [JsonProperty("contracts")]
        public long Contracts { set; get; }
        
        /// <summary>
        /// For Futures: The initial margin requirement for this level.
        /// </summary>
        [JsonProperty("initialMargin")]
        public decimal InitialMargin { set; get; }
        
        /// <summary>
        /// For Futures: The maintenance margin requirement for this level.
        /// </summary>
        [JsonProperty("maintenanceMargin")]
        public decimal MaintenanceMargin { set; get; }
    }
}
