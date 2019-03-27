using System;
using System.Runtime.Serialization;

namespace Lykke.CryptoFacilities.Exceptions
{
    /// <summary>
    /// Generic Exception
    /// </summary>
    public class CryptoFacilitiesException : Exception
    {
        public CryptoFacilitiesException()
        {
        }

        public CryptoFacilitiesException(string message) : base(message)
        {
        }

        public CryptoFacilitiesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CryptoFacilitiesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
