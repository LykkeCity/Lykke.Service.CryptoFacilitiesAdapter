using System;
using Lykke.СryptoFacilities.Models.Common;
using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Request
{
    public class CreateOrderRequestUrl : BaseRequestUrl
    {
        [JsonProperty("cliOrdId")]
        public string ClientOrderId { set; get; }
        
        [JsonProperty("orderType")]
        public OrderType Type { set; get; }
        
        [JsonProperty("symbol")]
        public string Symbol { set; get; }
        
        [JsonProperty("side")]
        public Side Side { set; get; }
        
        [JsonProperty("size")]
        public long Size { set; get; }

        [JsonProperty("limitPrice")]
        public decimal LimitPrice { set; get; }

        [JsonProperty("stopPrice")]
        public decimal? StopPrice { set; get; }
    }
}
