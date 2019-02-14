using System;
using System.Runtime.Serialization;

namespace Lykke.СryptoFacilities.Exceptions
{
    public class ApiLimitExceededException : СryptoFacilitiesException
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
