using System;
using System.Runtime.Serialization;

namespace Lykke.CryptoFacilities.Exceptions
{
    /// <summary>
    /// Invalid Account
    /// </summary>
    public class InvalidAccountException : CryptoFacilitiesException
    {
        public InvalidAccountException()
        {
        }

        public InvalidAccountException(string message) : base(message)
        {
        }

        public InvalidAccountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAccountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
