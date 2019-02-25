using Lykke.СryptoFacilities.Models.Common;
using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Request.BatchOrder
{
    public class BatchOrderCreateRequest : BatchOrderRequest
    {
        /// <summary>
        /// Request type.
        /// </summary>
        [JsonProperty("order")]
        public override BatchOrderType RequestType => BatchOrderType.Create;
        
        /// <summary>
        /// An arbitrary string provided client-side to tag the order for the purpose of mapping order sending instructions to the API’s response.
        /// Should be set only if RequestType is Create.
        /// </summary>
        [JsonProperty("order_tag")]
        public string OrderTag { set; get; }
        
        /// <summary>
        /// Type of the created order. Should be set only if RequestType is Create.
        /// </summary>
        [JsonProperty("orderType")]
        public OrderType? OrderType { set; get; }
        
        /// <summary>
        /// The symbol of the Futures. Should be set only if RequestType is Create.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { set; get; }

        /// <summary>
        /// The direction of the order. Should be set only if RequestType is Create.
        /// </summary>
        [JsonProperty("side")]
        public Side? Side { set; get; }

        /// <summary>
        /// The size associated with the order. Should be set only if RequestType is Create.
        /// </summary>
        [JsonProperty("size")]
        public long? Size { set; get; }
        
        /// <summary>
        /// The limit price associated with the order. Must not have more than 2 decimal places.
        /// Should be set only if RequestType is Create.
        /// </summary>
        [JsonProperty("limitPrice")]
        public decimal? Price { set; get; }

        /// <summary>
        /// The stop price associated with a stop order.
        /// Should be set only if RequestType is Create.
        /// </summary>
        [JsonProperty("stopPrice")]
        public decimal? StopPrice { set; get; }
    }
}
