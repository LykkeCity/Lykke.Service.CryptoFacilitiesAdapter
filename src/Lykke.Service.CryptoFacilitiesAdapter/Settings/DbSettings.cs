using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.CryptoFacilitiesAdapter.Settings
{
    public class DbSettings
    {
        [AzureTableCheck]
        public string LogsConnectionString { get; set; }
    }
}
