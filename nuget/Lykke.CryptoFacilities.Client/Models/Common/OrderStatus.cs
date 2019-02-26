using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.CryptoFacilities.Models.Common
{
    /// <summary>
    /// The status of the order
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class OrderStatus
    {
        /// <summary>
        /// The order was placed successfully.
        /// </summary>
        public const string Placed = "placed";

        /// <summary>
        /// The post-order will be attempted. If it is successful it will be shown in open orders.
        /// </summary>
        public const string Attempted = "attempted";

        /// <summary>
        /// The order was not placed because orderType is invalid.
        /// </summary>
        public const string InvalidOrderType = "invalidOrderType";

        /// <summary>
        /// The order was not placed because side is invalid.
        /// </summary>
        public const string InvalidSide = "invalidSide";

        /// <summary>
        /// The order was not placed because size is invalid.
        /// </summary>
        public const string InvalidSize = "invalidSize";

        /// <summary>
        /// The order was not placed because limitPrice and/or stopPrice are invalid.
        /// </summary>
        public const string InvalidPrice = "invalidPrice";

        /// <summary>
        /// The order was not placed because available funds are insufficient.
        /// </summary>
        public const string InsufficientAvailableFunds = "insufficientAvailableFunds";

        /// <summary>
        /// The order was not placed because it would be filled against an existing order belonging to the same account.
        /// </summary>
        public const string SelfFill = "selfFill";

        /// <summary>
        /// The order was not placed because the number of small open orders would exceed the permissible limit.
        /// </summary>
        public const string TooManySmallOrders = "tooManySmallOrders";

        /// <summary>
        /// The order was not placed because the market is suspended.
        /// </summary>
        public const string MarketSuspended = "marketSuspended";

        /// <summary>
        /// The order was not placed because the market is inactive.
        /// </summary>
        public const string MarketInactive = "marketInactive";

        /// <summary>
        /// The specified client id already exist.
        /// </summary>
        public const string ClientOrderIdAlreadyExist = "clientOrderIdAlreadyExist";

        /// <summary>
        /// The client id is longer than the permissible limit.
        /// </summary>
        public const string ClientOrderIdTooLong = "clientOrderIdTooLong";
    }
}
