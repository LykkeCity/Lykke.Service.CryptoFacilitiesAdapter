using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.СryptoFacilities.Models.Common
{
    /// <summary>
    /// The notification type.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum NotificationType
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("market")]
        Market,
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("general")]
        general,
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("new_feature")]
        NewFeature,
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bug_fix")]
        BugFix,
        
        /// <summary>
        /// Downtime will occur at EffectiveTime if Priority=="High"
        /// </summary>
        [JsonProperty("maintenance")]
        Maintenance,
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("settlement")]
        Settlement
    }
}
