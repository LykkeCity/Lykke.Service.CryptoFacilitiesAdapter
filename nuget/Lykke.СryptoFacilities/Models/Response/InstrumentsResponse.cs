using System;

namespace Lykke.СryptoFacilities.Models.Response
{
    public class InstrumentsResponse : BaseResponse
    {
        public Instrument[] Instruments { set; get; }
    }

    public class Instrument
    {
        public string Symbol { set; get; }
        
        public string Type { set; get; }
        
        public string Underlying { set; get; }
        
        public DateTime LastTradingTime { set; get; }
        
        public decimal? TickSize { set; get; }
        
        public int? ContractSize { set; get; }
        
        public bool Tradeable { set; get; }
        
        public InstrumentMarginLevel[] MarginLevels { set; get; }
    }

    public class InstrumentMarginLevel
    {
        public int Contracts { set; get; }
        
        public decimal InitialMargin { set; get; }
        
        public decimal MaintenanceMargin { set; get; }
    }
}
