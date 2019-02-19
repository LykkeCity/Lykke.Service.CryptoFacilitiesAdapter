using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.СryptoFacilities.Models.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderType
    {
        /// <summary>
        /// Default empty value.
        /// </summary>
        [JsonProperty("none")]
        [EnumMember(Value = "none")]
        None,
        /// <summary>
        /// A limit order.
        /// </summary>
        [JsonProperty("lmt")]
        [EnumMember(Value = "lmt")]
        LimitOrder,
        /// <summary>
        /// A post-only limit order.
        /// </summary>
        [JsonProperty("post")]
        [EnumMember(Value = "post")]
        PostOnly,
        /// <summary>
        /// A stop order.
        /// </summary>
        [JsonProperty("stp")]
        [EnumMember(Value = "stp")]
        StopOrder
    }
}
