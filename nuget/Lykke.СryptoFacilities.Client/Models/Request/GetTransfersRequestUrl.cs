using System;

namespace Lykke.СryptoFacilities.Models.Request
{
    /// <summary>
    /// Describes request for transfers list.
    /// </summary>
    public class GetTransfersRequestUrl : BaseRequestUrl
    {
        /// <summary>
        /// If not provided, returns the last 100 digital asset deposits or withdrawals w.r.t. ReceivedTime. If provided, returns the 100 entries before LastTransferTime w.r.t. ReceivedTime.
        /// </summary>
        public DateTime? LastTransferTime { set; get; }
    }
}
