using JetBrains.Annotations;

namespace Lykke.CryptoFacilities.Models.Response.History
{
    /// <summary>
    /// Response wrapper.
    /// </summary>
    [UsedImplicitly]
    public class HistoryResponse : BaseResponse
    {
        /// <summary>
        /// Historical information. The list is sorted descending by time.
        /// </summary>
        public HistoryRecord[] History { set; get; }
    }
}
