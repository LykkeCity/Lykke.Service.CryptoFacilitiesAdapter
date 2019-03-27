using System;
using System.Runtime.Serialization;

namespace Lykke.CryptoFacilities.Exceptions
{
    /// <summary>
    /// Nonce Below Threshold
    /// </summary>
    public class NonceBelowThresholdException : CryptoFacilitiesException
    {
        public NonceBelowThresholdException()
        {
        }

        public NonceBelowThresholdException(string message) : base(message)
        {
        }

        public NonceBelowThresholdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NonceBelowThresholdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
