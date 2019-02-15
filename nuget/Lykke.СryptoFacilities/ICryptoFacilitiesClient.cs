using System;
using System.Threading.Tasks;
using Lykke.СryptoFacilities.Models.Response;

namespace Lykke.СryptoFacilities
{
    public interface ICryptoFacilitiesClient
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
    }
}
