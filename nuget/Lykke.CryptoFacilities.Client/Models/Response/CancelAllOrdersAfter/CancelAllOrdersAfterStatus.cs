using System;
using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.Models.Response.CancelAllOrdersAfter
{
    /// <summary>
    /// Describes the result of setting timeout.
    /// </summary>
    public class CancelAllOrdersAfterStatus
    {
        /// <summary>
        /// The server date and time that server received the request.
        /// </summary>
        [JsonProperty("currentTime")]
        public DateTime CurrentTime { set; get; }
        
        /// <summary>
        /// The server date and time that server received the request.
        /// </summary>
        [JsonProperty("triggerTime")]
        public DateTime TriggerTime { set; get; }
    }
}
