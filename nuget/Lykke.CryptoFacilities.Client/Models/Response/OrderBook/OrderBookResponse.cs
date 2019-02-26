using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.Models.Response.OrderBook
{
    /// <summary>
    /// Response wrapper.
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class OrderBookResponse : BaseResponse
    {
        /// <summary>
        /// An object containing lists with bid and ask prices and sizes.
        /// </summary>
        [JsonProperty("orderBook")]
        public OrderBook OrderBook { set; get; }
    }
}
