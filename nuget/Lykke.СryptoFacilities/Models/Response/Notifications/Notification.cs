using System;
using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Response.Notifications
{
    /// <summary>
    /// CryptoFacilities notification.
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// The notification type.
        /// </summary>
        [JsonProperty("notifications")]
        public string Type { set; get; }
        
        /// <summary>
        /// The notification priority
        /// </summary>
        [JsonProperty("priority")]
        public string Priority { set; get; }
        
        /// <summary>
        /// The notification note. A short description about the specific  notification.
        /// </summary>
        [JsonProperty("note")]
        public string Note { set; get; }
        
        /// <summary>
        /// The time that notification is taking effect.
        /// </summary>
        [JsonProperty("effectiveTime")]
        public DateTime EffectiveTime { set; get; }
    }
}
