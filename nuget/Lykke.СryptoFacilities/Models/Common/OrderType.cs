using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.СryptoFacilities.Models.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderType
    {
        [JsonProperty("lmt")]
        [EnumMember(Value = "lmt")]
        LimitOrder,
        [JsonProperty("post")]
        [EnumMember(Value = "post")]
        PostOnly,
        [JsonProperty("stp")]
        [EnumMember(Value = "stp")]
        StopOrder
    }
}
