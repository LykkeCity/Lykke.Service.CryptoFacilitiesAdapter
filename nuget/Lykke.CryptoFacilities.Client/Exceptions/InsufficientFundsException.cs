using System;
using System.Runtime.Serialization;

namespace Lykke.CryptoFacilities.Exceptions
{
    /// <summary>
    /// Insufficient Funds
    /// </summary>
    public class InsufficientFundsException : CryptoFacilitiesException
    {
        public InsufficientFundsException()
        {
        }

        public InsufficientFundsException(string message) : base(message)
        {
        }

        public InsufficientFundsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InsufficientFundsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
