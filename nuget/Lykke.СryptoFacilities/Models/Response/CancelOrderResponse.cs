using System;
using Lykke.СryptoFacilities.Models.Common;
using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Response
{
    public class CancelOrderResponse : BaseResponse
    {
        [JsonProperty("cancelStatus")]
        public CancelOrderResult CancellationResult { set; get; }
    }

    public class CancelOrderResult
    {
        /// <summary>
        /// The cancelled order id.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { set; get; }

        /// <summary>
        /// The client order id. Shown only if client specified one.
        /// </summary>
        [JsonProperty("cliOrdId")]
        public string ClientOrderId { set; get; }

        /// <summary>
        /// The status of the order cancellation.
        /// </summary>
        [JsonProperty("status")]
        public CancelOrderStatus Status { set; get; }

        /// <summary>
        /// The date and time the order was received.
        /// </summary>
        [JsonProperty("receivedTime")]
        public DateTime ReceivedTime { set; get; }
    }
}
