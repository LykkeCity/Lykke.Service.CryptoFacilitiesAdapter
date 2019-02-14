using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.СryptoFacilities.Models.Common
{
    /// <summary>
    /// The status of the transfer request.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransferStatus
    {
        /// <summary>
        /// The withdrawal request was accepted and will be processed soon.
        /// </summary>
        [JsonProperty("accepted")]
        Accepted,
        
        /// <summary>
        /// The withdrawal request was not accepted because available funds are insufficient.
        /// </summary>
        [JsonProperty("insufficientAvailableFunds")]
        NotEnoughFunds,
        
        /// <summary>
        /// The withdrawal request is pending.
        /// </summary>
        [JsonProperty("pending")]
        Pending,
        
        /// <summary>
        /// The withdrawal request was processed.
        /// </summary>
        [JsonProperty("processed")]
        Processed
    }
}
