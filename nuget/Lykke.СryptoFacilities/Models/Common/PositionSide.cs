using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.СryptoFacilities.Models.Common
{
    /// <summary>
    /// Type of position.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PositionSide
    {
        /// <summary>
        /// Default empty value.
        /// </summary>
        [JsonProperty("none")]
        [EnumMember(Value = "none")]
        None,
        /// <summary>
        /// Long position.
        /// </summary>
        [JsonProperty("long")]
        [EnumMember(Value = "long")]
        Long,
        /// <summary>
        /// Short position.
        /// </summary>
        [JsonProperty("short")]
        [EnumMember(Value = "short")]
        Short
    }
}
