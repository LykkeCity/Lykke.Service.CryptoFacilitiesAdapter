using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.СryptoFacilities.Models.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Side
    {
        None,
        [JsonProperty("buy")]
        [EnumMember(Value = "buy")]
        Buy,
        [JsonProperty("sell")]
        [EnumMember(Value = "sell")]
        Sell
    }
}
