using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.СryptoFacilities.Models.Common
{
    /// <summary>
    /// Defines batch action.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BatchOrderType
    {
        /// <summary>
        /// Default empty value.
        /// </summary>
        [JsonProperty("none")]
        None,
        /// <summary>
        /// Used to request order creation.
        /// </summary>
        [JsonProperty("send")]
        Create,
        /// <summary>
        /// Used to request order cancellation.
        /// </summary>
        [JsonProperty("cancel")]
        Cancel
    }
}
