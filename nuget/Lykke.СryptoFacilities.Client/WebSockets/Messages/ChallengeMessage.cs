using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.WebSockets.Messages
{
    public class ChallengeMessage
    {
        [JsonProperty("event")]
        public string Event { set; get; }
        
        [JsonProperty("message")]
        public string Message { set; get; }
    }
}
