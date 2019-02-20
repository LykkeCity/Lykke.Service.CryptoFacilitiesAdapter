using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Response.CancelAllOrders
{
    /// <summary>
    /// Details about cancelled order.
    /// </summary>
    public class CancelledOrderItem
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
    }
}
