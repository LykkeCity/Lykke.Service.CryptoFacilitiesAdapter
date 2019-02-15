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
        [JsonProperty("time")]
        public DateTime Time { set; get; }
        
        [JsonProperty("trade_id")]
        public long TradeId { set; get; }
        
        [JsonProperty("price")]
        public decimal Price { set; get; }
        
        [JsonProperty("size")]
        public decimal? Size { set; get; }
        
        [JsonProperty("side")]
        public Side Side { set; get; }
        
        [JsonProperty("type")]
        public string Type { set; get; }
    }
}
