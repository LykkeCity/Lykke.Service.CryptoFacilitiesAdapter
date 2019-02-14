using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.СryptoFacilities.Models.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CancelOrderStatus
    {
        /// <summary>
        /// The order has been cancelled. This may only be part of the order as part may have been filled.
        /// </summary>
        [JsonProperty("cancelled")]
        Cancelled,

        /// <summary>
        /// The order was found completely filled and could not be cancelled
        /// </summary>
        [JsonProperty("filled")]
        Filled,

        /// <summary>
        /// The order was not found, either because it had already been cancelled or it never existed.
        /// </summary>
        [JsonProperty("notFound")]
        NotFound
    }
}
