using System;
using System.Runtime.Serialization;

namespace Lykke.СryptoFacilities.Exceptions
{
    public class СryptoFacilitiesException : Exception
    {
        public СryptoFacilitiesException()
        {
        }

        public СryptoFacilitiesException(string message) : base(message)
        {
        }

        public СryptoFacilitiesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected СryptoFacilitiesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
