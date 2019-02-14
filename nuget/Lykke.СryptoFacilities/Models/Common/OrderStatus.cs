using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.СryptoFacilities.Models.Common
{
    /// <summary>
    /// The status of the order
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderStatus
    {
        /// <summary>
        /// The order was placed successfully.
        /// </summary>
        [JsonProperty("placed")]
        Placed,
        
        /// <summary>
        /// The post-order will be attempted. If it is successful it will be shown in open orders.
        /// </summary>
        [JsonProperty("attempted")]
        Attempted,
        
        /// <summary>
        /// The order was not placed because orderType is invalid.
        /// </summary>
        [JsonProperty("invalidOrderType")]
        InvalidOrderType,
        
        /// <summary>
        /// The order was not placed because side is invalid.
        /// </summary>
        [JsonProperty("invalidSide")]
        InvalidSide,
        
        /// <summary>
        /// The order was not placed because size is invalid.
        /// </summary>
        [JsonProperty("invalidSize")]
        InvalidSize,
        
        /// <summary>
        /// The order was not placed because limitPrice and/or stopPrice are invalid.
        /// </summary>
        [JsonProperty("invalidPrice")]
        InvalidPrice,
        
        /// <summary>
        /// The order was not placed because available funds are insufficient.
        /// </summary>
        [JsonProperty("insufficientAvailableFunds")]
        InsufficientAvailableFunds,
        
        /// <summary>
        /// The order was not placed because it would be filled against an existing order belonging to the same account.
        /// </summary>
        [JsonProperty("selfFill")]
        SelfFill,
        
        /// <summary>
        /// The order was not placed because the number of small open orders would exceed the permissible limit.
        /// </summary>
        [JsonProperty("tooManySmallOrders")]
        TooManySmallOrders,
        
        /// <summary>
        /// The order was not placed because the market is suspended.
        /// </summary>
        [JsonProperty("marketSuspended")]
        MarketSuspended,

        /// <summary>
        /// The order was not placed because the market is inactive.
        /// </summary>
        [JsonProperty("marketInactive")]
        MarketInactive,

        /// <summary>
        /// The specified client id already exist.
        /// </summary>
        [JsonProperty("clientOrderIdAlreadyExist")]
        ClientOrderIdAlreadyExist,

        /// <summary>
        /// The client id is longer than the permissible limit.
        /// </summary>
        [JsonProperty("clientOrderIdTooLong")]
        ClientOrderIdTooLong
    }
}
