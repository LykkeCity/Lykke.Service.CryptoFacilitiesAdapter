using System;
using System.Runtime.Serialization;

namespace Lykke.CryptoFacilities.Exceptions
{
    /// <summary>
    /// Api Limit Exceeded
    /// </summary>
    public class ApiLimitExceededException : CryptoFacilitiesException
    {
        public ApiLimitExceededException()
        {
        }

        public ApiLimitExceededException(string message) : base(message)
        {
        }

        public ApiLimitExceededException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ApiLimitExceededException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
