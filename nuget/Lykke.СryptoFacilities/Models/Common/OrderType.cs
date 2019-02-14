using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.СryptoFacilities.Models.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderType
    {
        [JsonProperty("lmt")]
        LimitOrder,
        [JsonProperty("post")] 
        PostOnly,
        [JsonProperty("stp")] 
        StopOrder
    }
}
