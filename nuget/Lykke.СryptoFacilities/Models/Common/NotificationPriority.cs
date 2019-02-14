using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.СryptoFacilities.Models.Common
{
    /// <summary>
    /// The notification priority.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum NotificationPriority
    {
        [JsonProperty("low")]
        Low,
        
        [JsonProperty("medium")]
        Medium,
        
        [JsonProperty("high")]
        High
    }
}
