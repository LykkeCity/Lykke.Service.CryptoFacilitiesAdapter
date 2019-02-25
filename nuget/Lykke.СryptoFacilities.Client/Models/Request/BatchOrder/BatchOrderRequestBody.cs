using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Request.BatchOrder
{
    public class BatchOrderRequestBody : BaseRequestBody
    {
        /// <summary>
        /// Contains the list BatchOrder
        /// </summary>
        [JsonProperty("json")]
        public string Json { set; get; }
    }
}
