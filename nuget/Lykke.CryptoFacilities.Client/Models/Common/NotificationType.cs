using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.CryptoFacilities.Models.Common
{
    /// <summary>
    /// The notification type.
    /// </summary>
    public class NotificationType
    {
        public const string Market = "market";

        public const string General = "general";

        public const string NewFeature = "new_feature";

        public const string BugFix = "bug_fix";

        public const string Maintenance = "maintenance";

        public const string Settlement = "settlement";
    }
}
