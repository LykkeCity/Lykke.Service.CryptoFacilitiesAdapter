using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.СryptoFacilities.Models.Common
{
    /// <summary>
    /// The status of the orders cancellation
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public static class CancelAllOrdersStatus
    {
        /// <summary>
        /// Successful cancellation.
        /// </summary>
        public const string Cancelled = "cancelled";
        /// <summary>
        /// No open orders for cancellation.
        /// </summary>
        public const string NoOrdersToCancel = "noOrdersToCancel";
    }
}
