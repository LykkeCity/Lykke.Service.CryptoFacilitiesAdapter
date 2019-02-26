using JetBrains.Annotations;
using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.CryptoFacilitiesAdapter.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class CryptoFacilitiesAdapterSettings
    {
        public DbSettings Db { get; set; }
    }
}
