using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Response
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class OrderBookResponse : BaseResponse
    {
        /// <summary>
        /// An object containing lists with bid and ask prices and sizes.
        /// </summary>
        [JsonProperty("orderBook")]
        public OrderBook OrderBook { set; get; }
    }
    
    /// <summary>
    /// An object containing lists with bid and ask prices and sizes.
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class OrderBook
    {
        /// <summary>
        /// The first value of the inner list is the bid price, the second is the bid size. The outer list is sorted descending by bid price.
        /// </summary>
        [JsonProperty("bids")]
        public decimal[][] Bids { set; get; }
        
        /// <summary>
        /// The first value of the inner list is the ask price, the second is the ask size. The outer list is sorted ascending by ask price.
        /// </summary>
        [JsonProperty("asks")]
        public decimal[][] Asks { set; get; }
    }
}
