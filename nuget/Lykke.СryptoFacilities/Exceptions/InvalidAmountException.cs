using System;
using System.Runtime.Serialization;

namespace Lykke.СryptoFacilities.Exceptions
{
    /// <summary>
    /// Invalid Amount
    /// </summary>
    public class InvalidAmountException : СryptoFacilitiesException
    {
        public InvalidAmountException()
        {
        }

        public InvalidAmountException(string message) : base(message)
        {
        }

        public InvalidAmountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAmountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
