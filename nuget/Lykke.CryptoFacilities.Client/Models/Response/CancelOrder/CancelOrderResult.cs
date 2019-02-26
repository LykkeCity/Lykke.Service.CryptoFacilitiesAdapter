using System;
using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.Models.Response.CancelOrder
{
    /// <summary>
    /// An object containing information on the cancellation request.
    /// </summary>
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
        public string Status { set; get; }

        /// <summary>
        /// The date and time the order was received.
        /// </summary>
        [JsonProperty("receivedTime")]
        public DateTime ReceivedTime { set; get; }
    }
}
