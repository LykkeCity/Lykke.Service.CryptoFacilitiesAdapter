using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Response.CancelAllOrdersAfter
{
    /// <summary>
    /// Response wrapper.
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class CancelAllOrdersAfterResponse : BaseResponse
    {
        /// <summary>
        /// The status of the switch.
        /// </summary>
        [JsonProperty("status")]
        public CancelAllOrdersAfterStatus Status { set; get; }
    }
}
