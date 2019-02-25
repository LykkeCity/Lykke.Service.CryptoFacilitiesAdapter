using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Response.GetAccountInfo
{
    public class Account
    {
        /// <summary>
        /// The type of the account.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
            
        /// <summary>
        /// An object containing auxiliary account information. Returned only for margin accounts.
        /// </summary>
        [JsonProperty("auxiliary")]
        public AuxiliaryInfo Auxiliary { get; set; }
            
        /// <summary>
        /// An object containing the account’s margin requirements. Returned only for margin accounts.
        /// </summary>
        [JsonProperty("marginRequirements")]
        public MarginRequirements MarginRequirements { get; set; }
            
        /// <summary>
        /// An object containing the account’s margin trigger. Returned only for margin accounts.
        /// </summary>
        [JsonProperty("triggerEstimates")]
        public TriggerEstimates TriggerEstimates { get; set; }
            
        /// <summary>
        /// An object containing account balances.
        /// </summary>
        [JsonProperty("balances")]
        public Dictionary<string, decimal> Balances { get; set; }
    }
}
