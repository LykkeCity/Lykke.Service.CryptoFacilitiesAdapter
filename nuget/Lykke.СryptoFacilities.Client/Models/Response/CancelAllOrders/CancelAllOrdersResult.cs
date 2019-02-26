using System;
using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Response.CancelAllOrders
{
    public class CancelAllOrdersResult
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
        /// The symbol of the futures or the margin account to cancel or "all".
        /// </summary>
        [JsonProperty("cancelOnly")]
        public string CancelOnly { set; get; }
        
        /// <summary>
        /// A list of structures containing all the successfully cancelled orders.
        /// </summary>
        [JsonProperty("cancelledOrders")]
        public CancelledOrderItem[] CancelledOrders { set; get; }
    }
}
