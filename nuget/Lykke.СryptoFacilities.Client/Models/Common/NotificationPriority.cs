using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.СryptoFacilities.Models.Common
{
    /// <summary>
    /// The notification priority.
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public static class NotificationPriority
    {
        public const string Low = "low";

        public const string Medium = "medium";

        public const string High = "high";
    }
}
