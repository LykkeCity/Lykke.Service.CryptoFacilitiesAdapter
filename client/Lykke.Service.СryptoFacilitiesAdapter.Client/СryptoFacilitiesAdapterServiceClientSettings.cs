using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.СryptoFacilitiesAdapter.Client 
{
    /// <summary>
    /// СryptoFacilitiesAdapter client settings.
    /// </summary>
    public class СryptoFacilitiesAdapterServiceClientSettings 
    {
        /// <summary>Service url.</summary>
        [HttpCheck("api/isalive")]
        public string ServiceUrl {get; set;}
    }
}
