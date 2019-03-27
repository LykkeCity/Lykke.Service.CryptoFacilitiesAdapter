using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.Models.Response.GetTransfers
{
    /// <summary>
    /// Response wrapper.
    /// </summary>
    public class GetTransfersResponse : BaseResponse
    {
        /// <summary>
        /// A list containing structures with information on the account’s transfer history.
        /// The list is sorted descending by ReceivedTime.
        /// </summary>
        [JsonProperty("transfers")]
        public Transfer[] Transfers { set; get; }
    }
}
