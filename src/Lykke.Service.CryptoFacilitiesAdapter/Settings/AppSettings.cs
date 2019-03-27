using JetBrains.Annotations;
using Lykke.Sdk.Settings;

namespace Lykke.Service.CryptoFacilitiesAdapter.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AppSettings : BaseAppSettings
    {
        public CryptoFacilitiesAdapterSettings CryptoFacilitiesAdapterService { get; set; }
    }
}
