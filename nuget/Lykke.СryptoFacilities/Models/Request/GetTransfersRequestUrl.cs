using System;

namespace Lykke.СryptoFacilities.Models.Request
{
    public class GetTransfersRequestUrl : BaseRequestUrl
    {
        public DateTime? LastTransferTime { set; get; }
    }
}
