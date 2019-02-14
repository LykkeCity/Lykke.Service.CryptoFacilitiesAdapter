using System;

namespace Lykke.СryptoFacilities.Models.Request
{
    public class HistoryRequestUrl : BaseRequestUrl
    {
        public string Symbol { set; get; }
        
        public DateTime? LastTime { set; get; }
    }
}
