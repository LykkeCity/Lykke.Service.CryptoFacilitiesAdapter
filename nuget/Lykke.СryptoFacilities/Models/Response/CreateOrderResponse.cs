using System;
using Lykke.СryptoFacilities.Models.Common;
using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Response
{
    public class CreateOrderResponse : BaseResponse
    {
        /// <summary>
        /// A structure containing information on the send order request.
        /// </summary>
        [JsonProperty("sendStatus")]
        public CreatedOrder CreatedOrder { set; get; }
    }

    /// <summary>
    /// A structure containing information on the send order request.
    /// </summary>
    public class CreatedOrder
    {
        /// <summary>
        /// The unique identifier of the order.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { set; get; }

        /// <summary>
        /// The unique client order identifier. This field is returned only if the order has a client order id.
        /// </summary>
        [JsonProperty("cliOrdId")]
        public string ClientOrderId { set; get; }

        /// <summary>
        /// The status of the order.
        /// </summary>
        [JsonProperty("status")]
        public OrderStatus Status { set; get; }

        /// <summary>
        /// The date and time the order was received.
        /// </summary>
        [JsonProperty("receivedTime")]
        public DateTime ReceivedTime { set; get; }
    }
}
