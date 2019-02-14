using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.СryptoFacilities.Models.Common
{
    /// <summary>
    /// The status of the open order
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OpenOrderStatus
    {
        /// <summary>
        /// The entire size of the order is unfilled.
        /// </summary>
        [JsonProperty("untouched")]
        Untouched,
        
        /// <summary>
        /// The size of the order is partially but not entirely filled.
        /// </summary>
        [JsonProperty("partiallyFilled")]
        PartiallyFilled
    }
}
