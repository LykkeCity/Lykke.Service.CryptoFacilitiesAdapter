using System;
using System.Runtime.Serialization;

namespace Lykke.CryptoFacilities.Exceptions
{
    /// <summary>
    /// Nonce Duplicate
    /// </summary>
    public class NonceDuplicateException : CryptoFacilitiesException
    {
        public NonceDuplicateException()
        {
        }

        public NonceDuplicateException(string message) : base(message)
        {
        }

        public NonceDuplicateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NonceDuplicateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
