using System;
using Lykke.CryptoFacilities.Models.Common;
using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.Models.Response.GetOpenOrders
{
    /// <summary>
    /// Open order.
    /// </summary>
    public class OpenOrder
    {
        /// <summary>
        /// The date and time the order was received.
        /// </summary>
        [JsonProperty("receivedTime")]
        public DateTime ReceivedTime { set; get; }

        /// <summary>
        /// A structure containing information on the cancellation request.
        /// </summary>
        [JsonProperty("status")]
        public string Status { set; get; }
        
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
        /// The order type.
        /// </summary>
        [JsonProperty("orderType")]
        public OrderType Type { set; get; }
        
        /// <summary>
        /// The symbol of the futures the order refers to.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { set; get; }
        
        /// <summary>
        /// The direction of the order, either buy for a buy order or sell for a sell order.
        /// </summary>
        [JsonProperty("side")]
        public Side Side { set; get; }
        
        /// <summary>
        /// The unfilled size associated with the order.
        /// </summary>
        [JsonProperty("unfilledSize")]
        public long UnfilledSize { set; get; }
        
        /// <summary>
        /// The filled size associated with the order.
        /// </summary>
        [JsonProperty("filledSize")]
        public long FilledSize { set; get; }
        
        /// <summary>
        /// The limit price associated with the order.
        /// </summary>
        [JsonProperty("limitPrice")]
        public decimal LimitPrice { set; get; }
        
        /// <summary>
        /// If orderType is StopOrder: The stop price associated with the order. Null otherwise.
        /// </summary>
        [JsonProperty("stopPrice")]
        public decimal? StopPrice { set; get; }
    }
}
