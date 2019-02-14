using System;
using Lykke.СryptoFacilities.Models.Common;
using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Response
{
    public class GetOrderFillsResponse : BaseResponse
    {
        /// <summary>
        /// A list containing structures with information on filled orders. The list is sorted descending by FillTime.
        /// </summary>
        [JsonProperty("fills")]
        public OrderFill[] OrderFills { set; get; }
    }

    public class OrderFill
    {
        /// <summary>
        /// The date and time the order was filled.
        /// </summary>
        [JsonProperty("fillTime")]
        public DateTime FillTime { set; get; }
        
        /// <summary>
        /// The unique identifier of the order.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { set; get; }
        
        /// <summary>
        /// The unique identifier of the fill. Note that several fill_id can pertain to one OrderId (but not vice versa).
        /// </summary>
        [JsonProperty("fill_id")]
        public string FillId { set; get; }
        
        /// <summary>
        /// The unique client order identifier. This field is returned only if the order has a client order id.
        /// </summary>
        [JsonProperty("cliOrdId")]
        public string ClientOrderId { set; get; }
        
        /// <summary>
        /// The symbol of the futures the fill occurred in.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { set; get; }
        
        /// <summary>
        /// The direction of the order, either buy for a buy order or sell for a sell order.
        /// </summary>
        [JsonProperty("side")]
        public Side Side { set; get; }
        
        /// <summary>
        /// The size of the fill.
        /// </summary>
        [JsonProperty("size")]
        public long Size { set; get; }
        
        /// <summary>
        /// The price of the fill.
        /// </summary>
        [JsonProperty("price")]
        public decimal Price { set; get; }
        
        /// <summary>
        /// The classification of the fill.
        /// </summary>
        [JsonProperty("fillType")]
        public FillType Type { set; get; }
    }
}
