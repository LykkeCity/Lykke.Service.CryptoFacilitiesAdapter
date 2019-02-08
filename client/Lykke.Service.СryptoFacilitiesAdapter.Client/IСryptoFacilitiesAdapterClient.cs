using JetBrains.Annotations;

namespace Lykke.Service.СryptoFacilitiesAdapter.Client
{
    /// <summary>
    /// СryptoFacilitiesAdapter client interface.
    /// </summary>
    [PublicAPI]
    public interface IСryptoFacilitiesAdapterClient
    {
        // Make your app's controller interfaces visible by adding corresponding properties here.
        // NO actual methods should be placed here (these go to controller interfaces, for example - IСryptoFacilitiesAdapterApi).
        // ONLY properties for accessing controller interfaces are allowed.

        /// <summary>Application Api interface</summary>
        IСryptoFacilitiesAdapterApi Api { get; }
    }
}
