using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Common
{
    /// <summary>
    /// The type of the transfer
    /// </summary>
    public enum TransferType
    {
        [JsonProperty("deposit")]
        Deposit,
        
        [JsonProperty("withdrawal")]
        Withdrawal
    }
}
