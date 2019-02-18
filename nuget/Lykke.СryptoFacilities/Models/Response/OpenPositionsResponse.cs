using System;
using System.Collections.Generic;
using Lykke.СryptoFacilities.Models.Common;
using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Response
{
    public class OpenPositionsResponse : BaseResponse
    {
        /// <summary>
        /// A list containing structures with information on open positions. The list is sorted descending by FillTime.
        /// </summary>
        [JsonProperty("openPositions")]
        public OpenPosition[] OpenPositions { get; set; }
    }
    
    /// <summary>
    /// Information on open position.
    /// </summary>
    public class OpenPosition
    {
        /// <summary>
        /// The direction of the position, either long for a long position or short for a short position.
        /// </summary>
        [JsonProperty("side")]
        public PositionSide Side { get; set; }
        
        /// <summary>
        /// The symbol of the Futures.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        
        /// <summary>
        /// The average price at which the position was entered into.
        /// </summary>
        [JsonProperty("price")]
        public decimal Price { get; set; }
        
        /// <summary>
        /// The date and time the position was entered into.
        /// </summary>
        [JsonProperty("fillTime")]
        public DateTime FillTime { get; set; }
        
        /// <summary>
        /// The size of the position.
        /// </summary>
        [JsonProperty("size")]
        public long Size { get; set; }
    }
}
