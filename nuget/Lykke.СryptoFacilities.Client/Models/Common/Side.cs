using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.СryptoFacilities.Models.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Side
    {
        [JsonProperty("none")]
        None,
        [JsonProperty("buy")]
        Buy,
        [JsonProperty("sell")]
        Sell
    }
}
