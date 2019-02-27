using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.WebSockets.FeedMessages
{
    public class OpenPositionsMessage
    {
        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("positions")]
        public PositionMessage[] Positions { get; set; }
    }
}
