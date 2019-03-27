using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.Models.Response.GetAccountInfo
{
    /// <summary>
    /// Response wrapper.
    /// </summary>
    public class GetAccountInfoResponse : BaseResponse
    {
        /// <summary>
        /// An object containing structures with account-related information for all margin and cash accounts.
        /// </summary>
        [JsonProperty("accounts")]
        public AccountsInfo Accounts { set; get; }
    }
}
