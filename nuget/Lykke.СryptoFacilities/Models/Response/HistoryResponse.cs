using System;
using JetBrains.Annotations;
using Lykke.СryptoFacilities.Models.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Lykke.СryptoFacilities.Models.Response
{
    [UsedImplicitly]
    public class HistoryResponse : BaseResponse
    {
        public HistoryRecord[] History { set; get; }
    }

    [UsedImplicitly]
    public class HistoryRecord
    {
        public DateTime Time { set; get; }
        
        [JsonProperty("trade_id")]
        public long TradeId { set; get; }
        
        public decimal Price { set; get; }
        
        public decimal? Size { set; get; }
        
        public Side Side { set; get; }
        
        public string Type { set; get; }
    }
}
