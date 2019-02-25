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
        None,
        /// <summary>
        /// A limit order.
        /// </summary>
        [JsonProperty("lmt")]
        LimitOrder,
        /// <summary>
        /// A post-only limit order.
        /// </summary>
        [JsonProperty("post")]
        PostOnly,
        /// <summary>
        /// A stop order.
        /// </summary>
        [JsonProperty("stp")]
        StopOrder
    }
}
