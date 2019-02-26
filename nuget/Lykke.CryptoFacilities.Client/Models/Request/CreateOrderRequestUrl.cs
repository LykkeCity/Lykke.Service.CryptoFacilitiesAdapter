using System;
using Lykke.CryptoFacilities.Models.Common;
using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.Models.Request
{
    /// <summary>
    /// Describes order creation attempt.
    /// </summary>
    public class CreateOrderRequestUrl : BaseRequestUrl
    {
        /// <summary>
        /// The order type.
        /// </summary>
        [JsonProperty("orderType")]
        public OrderType Type { set; get; }
        
        /// <summary>
        /// The symbol of the Futures.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { set; get; }
        
        /// <summary>
        /// The direction of the order.
        /// </summary>
        [JsonProperty("side")]
        public Side Side { set; get; }
        
        /// <summary>
        /// The size associated with the order.
        /// </summary>
        [JsonProperty("size")]
        public long Size { set; get; }

        /// <summary>
        /// The limit price associated with the order. Must not have more than 2 decimal places.
        /// </summary>
        [JsonProperty("limitPrice")]
        public decimal LimitPrice { set; get; }

        /// <summary>
        /// The stop price associated with a stop order.
        /// </summary>
        [JsonProperty("stopPrice")]
        public decimal? StopPrice { set; get; }
        
        /// <summary>
        /// The order identity that is specified from the user. It must be globally unique.
        /// </summary>
        [JsonProperty("cliOrdId")]
        public string ClientOrderId { set; get; }
    }
}
