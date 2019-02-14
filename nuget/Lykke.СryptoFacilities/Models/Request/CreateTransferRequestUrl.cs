using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Request
{
    public class CreateTransferRequestUrl : BaseRequestUrl
    {
        /// <summary>
        /// The name of the cash or margin account to move funds from. The names and balances of the accounts can be seen with the /accounts endpoint.
        /// </summary>
        [JsonProperty("fromAccount")]
        public string FromAccount { set; get; }

        /// <summary>
        /// The name of the cash or margin account to move funds to. The names and balances of the accounts can be seen with the /accounts endpoint.
        /// </summary>
        [JsonProperty("toAccount")]
        public string ToAccount { set; get; }

        /// <summary>
        /// The unit to transfer.
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { set; get; }

        /// <summary>
        /// The amount to transfer.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { set; get; }
    }
}
