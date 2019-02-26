using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.Models.Response.CancelOrder
{
    /// <summary>
    /// Response wrapper.
    /// </summary>
    public class CancelOrderResponse : BaseResponse
    {
        /// <summary>
        /// An object containing information on the cancellation request.
        /// </summary>
        [JsonProperty("cancelStatus")]
        public CancelOrderResult CancellationResult { set; get; }
    }
}
