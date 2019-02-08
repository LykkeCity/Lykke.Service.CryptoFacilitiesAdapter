using System;
using System.Runtime.Serialization;

namespace Lykke.СryptoFacilities
{
    public class СryptoАacilitiesException : Exception
    {
        public СryptoАacilitiesException()
        {
        }

        public СryptoАacilitiesException(string message) : base(message)
        {
        }

        public СryptoАacilitiesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected СryptoАacilitiesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}