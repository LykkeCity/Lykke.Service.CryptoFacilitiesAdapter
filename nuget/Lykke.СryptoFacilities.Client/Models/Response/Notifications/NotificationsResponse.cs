using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Response.Notifications
{
    /// <summary>
    /// Response wrapper.
    /// </summary>
    public class NotificationsResponse : BaseResponse
    {
        /// <summary>
        /// A list containing the notifications.
        /// </summary>
        [JsonProperty("notifications")]
        public Notification[] Notifications { set; get; }
    }
}
