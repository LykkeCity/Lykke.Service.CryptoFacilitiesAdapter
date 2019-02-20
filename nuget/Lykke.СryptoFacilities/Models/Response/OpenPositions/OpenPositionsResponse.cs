using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Response.OpenPositions
{
    /// <summary>
    /// Response wrapper.
    /// </summary>
    public class OpenPositionsResponse : BaseResponse
    {
        /// <summary>
        /// A list containing structures with information on open positions. The list is sorted descending by FillTime.
        /// </summary>
        [JsonProperty("openPositions")]
        public OpenPosition[] OpenPositions { get; set; }
    }
}
