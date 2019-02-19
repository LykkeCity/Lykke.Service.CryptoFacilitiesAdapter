using System;
using System.Runtime.Serialization;

namespace Lykke.СryptoFacilities.Exceptions
{
    /// <summary>
    /// Invalid Account
    /// </summary>
    public class InvalidAccountException : СryptoFacilitiesException
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
