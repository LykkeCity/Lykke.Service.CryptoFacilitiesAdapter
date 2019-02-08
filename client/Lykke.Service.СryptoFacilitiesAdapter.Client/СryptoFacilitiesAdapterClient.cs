using Lykke.HttpClientGenerator;

namespace Lykke.Service.СryptoFacilitiesAdapter.Client
{
    /// <summary>
    /// СryptoFacilitiesAdapter API aggregating interface.
    /// </summary>
    public class СryptoFacilitiesAdapterClient : IСryptoFacilitiesAdapterClient
    {
        // Note: Add similar Api properties for each new service controller

        /// <summary>Inerface to СryptoFacilitiesAdapter Api.</summary>
        public IСryptoFacilitiesAdapterApi Api { get; private set; }

        /// <summary>C-tor</summary>
        public СryptoFacilitiesAdapterClient(IHttpClientGenerator httpClientGenerator)
        {
            Api = httpClientGenerator.Generate<IСryptoFacilitiesAdapterApi>();
        }
    }
}
