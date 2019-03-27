using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.Models.Response.GetOpenOrders
{
    /// <summary>
    /// Response wrapper.
    /// </summary>
    public class GetOpenOrdersResponse : BaseResponse
    {
        /// <summary>
        /// A list containing structures with information on open orders. The list is sorted descending by ReceivedTime.
        /// </summary>
        [JsonProperty("openOrders")]
        public OpenOrder[] Orders { set; get; }
    }
}
