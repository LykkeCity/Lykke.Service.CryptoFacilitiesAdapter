using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.CryptoFacilities.Models.Common
{
    /// <summary>
    /// The status of the open order
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class OpenOrderStatus
    {
        /// <summary>
        /// The entire size of the order is unfilled.
        /// </summary>
        public const string Untouched = "untouched";
        
        /// <summary>
        /// The size of the order is partially but not entirely filled.
        /// </summary>
        public const string PartiallyFilled = "partiallyFilled";
    }
}
