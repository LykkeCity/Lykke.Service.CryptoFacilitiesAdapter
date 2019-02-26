using JetBrains.Annotations;
using Lykke.Sdk.Settings;

namespace Lykke.Service.СryptoFacilitiesAdapter.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AppSettings : BaseAppSettings
    {
        public СryptoFacilitiesAdapterSettings СryptoFacilitiesAdapterService { get; set; }
    }
}
