using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.СryptoFacilities.Models.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PositionSide
    {
        [JsonProperty("long")]
        Long,
        [JsonProperty("short")]
        Short
    }
}
