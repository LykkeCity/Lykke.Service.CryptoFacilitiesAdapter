using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.СryptoFacilities.Models.Common
{
    /// <summary>
    /// The status of the orders cancellation
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CancelAllOrdersStatus
    {
        /// <summary>
        /// Successful cancellation.
        /// </summary>
        [JsonProperty("cancelled")]
        Cancelled,
        /// <summary>
        /// No open orders for cancellation.
        /// </summary>
        [JsonProperty("noOrdersToCancel")]
        NoOrdersToCancel
    }
}
