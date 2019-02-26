using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.Models.Response.GetOrderFills
{
    /// <summary>
    /// Response wrapper.
    /// </summary>
    public class GetOrderFillsResponse : BaseResponse
    {
        /// <summary>
        /// A list containing structures with information on filled orders. The list is sorted descending by FillTime.
        /// </summary>
        [JsonProperty("fills")]
        public OrderFill[] OrderFills { set; get; }
    }
}
