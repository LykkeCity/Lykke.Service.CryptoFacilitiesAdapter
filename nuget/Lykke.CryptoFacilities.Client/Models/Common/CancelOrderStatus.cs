using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.CryptoFacilities.Models.Common
{
    /// <summary>
    /// Status of the attempted cancellation.
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class CancelOrderStatus
    {
        /// <summary>
        /// The order has been cancelled. This may only be part of the order as part may have been filled.
        /// </summary>
        public const string Cancelled = "cancelled";

        /// <summary>
        /// The order was found completely filled and could not be cancelled
        /// </summary>
        public const string Filled = "filled";

        /// <summary>
        /// The order was not found, either because it had already been cancelled or it never existed.
        /// </summary>
        public const string NotFound = "notFound";
    }
}
