using System;
using Common;

namespace Lykke.СryptoFacilities.Models.Response
{
    /// <summary>
    /// Base response type.
    /// </summary>
    public class BaseResponse
    {
        /// <summary>
        /// Indicates whether the call was successful or not.
        /// </summary>
        public string Result { get; set; }
        
        /// <summary>
        /// Server response time.
        /// </summary>
        public DateTime ServerTime { get; set; }
        
        /// <summary>
        /// Contains error code if present.
        /// </summary>
        public string Error { get; set; }
    }
}
