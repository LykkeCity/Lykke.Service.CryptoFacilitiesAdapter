using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.Models.Response.Instruments
{
    /// <summary>
    /// Instrument margin level.
    /// </summary>
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
