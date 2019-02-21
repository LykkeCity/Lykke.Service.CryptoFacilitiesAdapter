using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.WebSockets.Messages
{
    public class RequestChallengeMessage : IRequest
    {
        public RequestChallengeMessage(string apiKey)
        {
            ApiKey = apiKey;
        }
        
        [JsonProperty("event")]
        public string Event { get; private set; } = "challenge";
        
        [JsonProperty("api_key")]
        public string ApiKey { set; get; }
    }
}
