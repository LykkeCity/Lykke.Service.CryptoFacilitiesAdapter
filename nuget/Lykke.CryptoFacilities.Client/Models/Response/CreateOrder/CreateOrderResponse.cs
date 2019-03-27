using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.Models.Response.CreateOrder
{
    /// <summary>
    /// Response wrapper.
    /// </summary>
    public class CreateOrderResponse : BaseResponse
    {
        /// <summary>
        /// A structure containing information on the send order request.
        /// </summary>
        [JsonProperty("sendStatus")]
        public CreatedOrder CreatedOrder { set; get; }
    }
}
