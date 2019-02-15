using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.СryptoFacilities.Models.Common
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public static class AccountType
    {
        public const string CashAccount = "cashAccount";
        
        public const string MarginAccount = "marginAccount";
    }
}
