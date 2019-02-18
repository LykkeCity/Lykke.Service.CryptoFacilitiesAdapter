using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.СryptoFacilities.Models.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BatchOrderType
    {
        [EnumMember(Value = "send")]
        Create,
        [EnumMember(Value = "cancel")]
        Cancel
    }
}
