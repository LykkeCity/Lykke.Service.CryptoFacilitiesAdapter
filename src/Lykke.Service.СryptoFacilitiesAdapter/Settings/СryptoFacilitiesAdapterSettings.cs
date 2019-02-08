using JetBrains.Annotations;
using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.СryptoFacilitiesAdapter.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class СryptoFacilitiesAdapterSettings
    {
        public DbSettings Db { get; set; }
    }
}
