using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.СryptoFacilities.Models.Common
{
    /// <summary>
    /// Account type.
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public static class AccountType
    {
        /// <summary>
        /// Cash account.
        /// </summary>
        public const string CashAccount = "cashAccount";
        
        /// <summary>
        /// Margin account.
        /// </summary>
        public const string MarginAccount = "marginAccount";
    }
}
