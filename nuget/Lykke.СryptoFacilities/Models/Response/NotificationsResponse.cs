using System;
using Lykke.СryptoFacilities.Models.Common;
using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Response
{
    public class NotificationsResponse : BaseResponse
    {
        /// <summary>
        /// A list containing the notifications.
        /// </summary>
        [JsonProperty("notifications")]
        public Notification[] Notifications { set; get; }
    }

    public class Notification
    {
        /// <summary>
        /// The notification type.
        /// </summary>
        [JsonProperty("notifications")]
        public NotificationType Type { set; get; }
        
        /// <summary>
        /// The notification priority
        /// </summary>
        [JsonProperty("priority")]
        public NotificationPriority Priority { set; get; }
        
        /// <summary>
        /// The notification note. A short description about the specific  notification.
        /// </summary>
        [JsonProperty("note")]
        public NotificationPriority Note { set; get; }
        
        /// <summary>
        /// The time that notification is taking effect.
        /// </summary>
        [JsonProperty("effectiveTime")]
        public DateTime EffectiveTime { set; get; }
    }
}
