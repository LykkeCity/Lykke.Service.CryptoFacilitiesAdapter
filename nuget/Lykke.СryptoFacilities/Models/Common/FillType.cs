using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.СryptoFacilities.Models.Common
{
    /// <summary>
    /// The classification of the fill.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FillType
    {
        /// <summary>
        /// User has a limit order that gets filled.
        /// </summary>
        [JsonProperty("maker")]
        Maker,
        
        /// <summary>
        /// User makes an execution that crosses the spread.
        /// </summary>
        [JsonProperty("taker")]
        Taker,
        
        /// <summary>
        /// Execution is result of a liquidation.
        /// </summary>
        [JsonProperty("liquidation")]
        Liquidation,
        
        /// <summary>
        /// Execution is a result of a counterparty receiving an Assignment in PAS.
        /// </summary>
        [JsonProperty("assignee")]
        Assignee,
        
        /// <summary>
        /// Execution is a result of user assigning their position due to failed liquidation.
        /// </summary>
        [JsonProperty("assignor")]
        Assignor
    }
}
