using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Response
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class CancelAllOrdersAfterResponse : BaseResponse
    {
        /// <summary>
        /// The status of the switch.
        /// </summary>
        [JsonProperty("status")]
        public CancelAllOrdersAfterStatus Status { set; get; }
    }

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
