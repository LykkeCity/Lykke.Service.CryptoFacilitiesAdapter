using JetBrains.Annotations;

namespace Lykke.CryptoFacilities
{
    /// <summary>
    /// Settings for the CryptoFacilities REST client.
    /// </summary>
    [PublicAPI]
    public class CryptoFacilitiesApiSettings
    {
        /// <summary>
        /// Path to API
        /// </summary>
        public string ApiPath { set; get; }
        
        /// <summary>
        /// Api Private Key
        /// </summary>
        public string ApiPrivateKey { set; get; }
        
        /// <summary>
        /// Api Public Key
        /// </summary>
        public string ApiPublicKey { set; get; }
        
        /// <summary>
        /// Whether client should check certificate.
        /// </summary>
        public bool CheckCertificate { set; get; }
    }
}
