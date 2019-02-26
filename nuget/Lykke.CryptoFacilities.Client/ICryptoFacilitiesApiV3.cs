using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Lykke.CryptoFacilities.Models.Common;
using Lykke.CryptoFacilities.Models.Response;
using Lykke.CryptoFacilities.Models.Response.CancelAllOrders;
using Lykke.CryptoFacilities.Models.Response.CancelAllOrdersAfter;
using Lykke.CryptoFacilities.Models.Response.CancelOrder;
using Lykke.CryptoFacilities.Models.Response.CreateOrder;
using Lykke.CryptoFacilities.Models.Response.GetAccountInfo;
using Lykke.CryptoFacilities.Models.Response.GetOpenOrders;
using Lykke.CryptoFacilities.Models.Response.GetOrderFills;
using Lykke.CryptoFacilities.Models.Response.GetTransfers;
using Lykke.CryptoFacilities.Models.Response.History;
using Lykke.CryptoFacilities.Models.Response.Instruments;
using Lykke.CryptoFacilities.Models.Response.Notifications;
using Lykke.CryptoFacilities.Models.Response.OpenPositions;
using Lykke.CryptoFacilities.Models.Response.OrderBook;
using Lykke.CryptoFacilities.Models.Response.Ticker;

namespace Lykke.CryptoFacilities
{
    /// <summary>
    /// Provides connection to CryptoFacilities API.
    /// </summary>
    [PublicAPI]
    public interface ICryptoFacilitiesApiV3
    {
        /// <summary>
        /// This endpoint returns specifications for all currently listed Futures contracts and indices.
        /// Authentication is not required.
        /// </summary>
        /// <returns>All currently listed Futures contracts and indices.</returns>
        Task<Instrument[]> GetInstrumentsAsync();

        /// <summary>
        /// This endpoint returns current market data for all currently listed Futures contracts and indices.
        /// Authentication is not required.
        /// </summary>
        /// <returns>All currently listed Futures contracts and indices.</returns>
        Task<TickerInfo[]> GetTickersAsync();

        /// <summary>
        /// This endpoint returns the entire non-cumulative order book of currently listed Futures contracts.
        /// Authentication is not required.
        /// </summary>
        /// <param name="symbol">The symbol of the Futures.</param>
        /// <returns>Entire non-cumulative order book of currently listed Futures contracts.</returns>
        Task<OrderBook> GetOrderBookAsync(string symbol);

        /// <summary>
        /// This endpoint returns the last 100 trades from the specified lastTime value - if no value specified will return 100 trades.
        /// Authentication is not required.
        /// </summary>
        /// <param name="symbol">The symbol of the Futures.</param>
        /// <param name="lastTime">Returns 100 trades from the specified lastTime value.</param>
        /// <returns>Last 100 trades from the specified lastTime value - if no value specified will return 100 trades.</returns>
        Task<HistoryRecord[]> GetHistoryAsync(string symbol, DateTime? lastTime = default(DateTime?));

        /// <summary>
        /// This endpoint allows you to transfer funds between two margin accounts with the same collateral currency, or between a margin account and your cash account.
        /// Authentication is required.
        /// </summary>
        /// <param name="fromAccount">The name of the cash or margin account to move funds from. The names and balances of the accounts can be seen with the Accounts endpoint.</param>
        /// <param name="toAccount">The name of the cash or margin account to move funds to. The names and balances of the accounts can be seen with the /accounts endpoint.</param>
        /// <param name="unit">The unit to transfer.</param>
        /// <param name="amount">The amount to transfer.</param>
        Task CreateTransferAsync(string fromAccount, string toAccount, string unit, decimal amount);

        /// <summary>
        /// This endpoint returns key information relating to all your Crypto Facilities accounts which may either be cash accounts or margin accounts.
        /// This includes digital asset balances, instrument balances, margin requirements, margin trigger estimates and auxiliary information such as available funds, PnL of open positions and portfolio value.
        /// Authentication is required.
        /// </summary>
        /// <returns>Info on accounts.</returns>
        Task<AccountsInfo> GetAccountsInfoAsync();

        /// <summary>
        /// This endpoint allows sending a limit or stop order for a currently listed Futures contract.
        /// Authentication is required.
        /// </summary>
        /// <param name="clientOrderId">The order identity that is specified from the user. It must be globally unique. Can be null.</param>
        /// <param name="type">The order type.</param>
        /// <param name="symbol">The symbol of the Futures.</param>
        /// <param name="side">The direction of the order.</param>
        /// <param name="size">The size associated with the order.</param>
        /// <param name="limitPrice">The limit price associated with the order. Must not have more than 2 decimal places.</param>
        /// <param name="stopPrice">The stop price associated with a stop order.</param>
        /// <returns>Info on newly created order.</returns>
        Task<CreatedOrder> CreateOrderAsync(string clientOrderId, OrderType type, string symbol, Side side, long size,
            decimal limitPrice, decimal? stopPrice = default(decimal?));

        /// <summary>
        /// This endpoint allows cancelling an open order for a Futures contract.
        /// Authentication is required.
        /// </summary>
        /// <param name="orderId">The unique identifier of the order to be cancelled. Can be null.</param>
        /// <param name="clientOrderId">The client unique identifier of the order to be cancelled. Can be null.</param>
        /// <returns>Info on performed cancellation.</returns>
        Task<CancelOrderResult> CancelOrderAsync(string orderId, string clientOrderId);

        /// <summary>
        /// This endpoint allows cancelling orders which are associated with a future's contract or a margin account.
        /// If no arguments are specified all open orders will be cancelled.
        /// Authentication is required.
        /// </summary>
        /// <param name="symbol">A margin account or future product to cancel all open orders.</param>
        /// <returns>Info on performed cancellations.</returns>
        Task<CancelAllOrdersResult> CancelAllOrdersAsync(string symbol = null);

        /// <summary>
        /// This endpoint provides a Dead Man's Switch mechanism to protect the user from network malfunctions.
        /// The user can send a request with a timeout in seconds which will trigger a countdown timer that will cancel all user orders when timeout expires.
        /// The user has to keep sending request to push back the timeout expiration or they can deactivate the mechanism by specifying a timeout of zero (0).
        /// The recommended mechanism usage is making a call every 15 to 20 seconds and provide a timeout of 60 seconds.
        /// This allows the user to keep the orders in place on a brief network failure, while keeping them safe in case of a network breakdown.
        /// Authentication is required.
        /// </summary>
        /// <param name="timeout">The timeout specified in seconds.</param>
        /// <returns>Info on attempt to set timeout.</returns>
        Task<CancelAllOrdersAfterStatus> CancelAllOrdersAfterAsync(long timeout);

        /// <summary>
        /// This endpoint returns information on all open orders for all Futures contracts.
        /// Authentication is required.
        /// </summary>
        /// <returns>Information on all open orders for all Futures contracts.</returns>
        Task<OpenOrder[]> GetOpenOrdersAsync();

        /// <summary>
        /// This endpoint returns information on filled orders for all futures contracts.
        /// Authentication is required.
        /// </summary>
        /// <param name="lastFillTime">If not provided, returns the last 100 fills in any futures contract. If provided, returns the 100 entries before lastFillTime.</param>
        /// <returns></returns>
        Task<OrderFill[]> GetOrderFillsAsync(DateTime? lastFillTime = default(DateTime?));

        /// <summary>
        /// This endpoint returns the size and average entry price of all open positions in Futures contracts. This includes Futures contracts that have matured but have not yet been settled.
        /// Authentication is required.
        /// </summary>
        /// <returns>The size and average entry price of all open positions in Futures contracts.</returns>
        Task<OpenPosition[]> GetOpenPositionsAsync();

        /// <summary>
        /// This endpoint provides the platform's notifications.
        /// Authentication is required.
        /// </summary>
        /// <returns>Platform's notifications.</returns>
        Task<Notification[]> GetNotificationsAsync();

        /// <summary>
        /// This endpoint returns information on digital asset deposits and withdrawals to and from a CryptoFacilities account.
        /// Authentication is required.
        /// </summary>
        /// <param name="lastTransferTime">If not provided, returns the last 100 digital asset deposits or withdrawals w.r.t. ReceivedTime. If provided, returns the 100 entries before lastTransferTime w.r.t. ReceivedTime</param>
        /// <returns>Information on digital asset deposits and withdrawals.</returns>
        Task<Transfer[]> GetTransfersAsync(DateTime? lastTransferTime = default(DateTime?));
    }
}
