using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Response.CancelAllOrders
{
    /// <summary>
    /// Response wrapper.
    /// </summary>
    public class CancelAllOrdersResponse : BaseResponse
    {
        /// <summary>
        /// Actual response.
        /// </summary>
        [JsonProperty("cancelStatus")]
        public CancelAllOrdersResult CancellationResult { set; get; }
    }
}
