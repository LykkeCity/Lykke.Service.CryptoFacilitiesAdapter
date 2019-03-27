using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.CryptoFacilities.Models.Common
{
    /// <summary>
    /// The status of the transfer request.
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class TransferStatus
    {
        /// <summary>
        /// The withdrawal request was accepted and will be processed soon.
        /// </summary>
        public const string Accepted = "accepted";
        
        /// <summary>
        /// The withdrawal request was not accepted because available funds are insufficient.
        /// </summary>
        public const string NotEnoughFunds = "insufficientAvailableFunds";

        /// <summary>
        /// The withdrawal request is pending.
        /// </summary>
        public const string Pending = "pending";

        /// <summary>
        /// The withdrawal request was processed.
        /// </summary>
        public const string Processed = "processed";
    }
}
