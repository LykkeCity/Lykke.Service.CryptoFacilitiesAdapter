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
        [EnumMember(Value = "none")]
        [JsonProperty("none")]
        None,
        /// <summary>
        /// Used to request order creation.
        /// </summary>
        [EnumMember(Value = "send")]
        [JsonProperty("send")]
        Create,
        /// <summary>
        /// Used to request order cancellation.
        /// </summary>
        [EnumMember(Value = "cancel")]
        [JsonProperty("cancel")]
        Cancel
    }
}
