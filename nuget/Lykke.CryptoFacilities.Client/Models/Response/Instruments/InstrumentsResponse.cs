using JetBrains.Annotations;

namespace Lykke.CryptoFacilities.Models.Response.Instruments
{
    /// <summary>
    /// Response wrapper.
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class InstrumentsResponse : BaseResponse
    {
        /// <summary>
        /// An array containing objects for each available instrument. The list is in no particular order.
        /// </summary>
        public Instrument[] Instruments { set; get; }
    }
}
