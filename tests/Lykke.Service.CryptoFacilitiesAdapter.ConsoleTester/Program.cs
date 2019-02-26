using System;
using System.Linq;
using System.Threading;
using Common;
using Lykke.CryptoFacilities;
using Lykke.CryptoFacilities.Models.Common;
using Lykke.CryptoFacilities.Models.Request;

namespace Lykke.Service.CryptoFacilitiesAdapter.ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var client = new CryptoFacilitiesClient(
                "https://www.cryptofacilities.com/derivatives",
                "",
                "",
                false);
            
            var ob = client.GetOrderBookAsync("pi_xbtusd").GetAwaiter().GetResult();

            var price = ob.Bids.Min(x => x[0]) - 1000;
            
            Console.WriteLine(client.BatchOrdersAsync(new[] {new BatchOrderCreateRequest
            {
                ClientOrderId = Guid.NewGuid().ToString(),
                OrderTag = Guid.NewGuid().ToString(),
                OrderType = OrderType.LimitOrder,
                Side = Side.Buy,
                Price = price,
                Size = 12,
                Symbol = "pi_xbtusd"
            }}).GetAwaiter().GetResult().ToJson());
            //Console.WriteLine(client.GetInstrumentsAsync().GetAwaiter().GetResult().ToJson()); return;
            //Console.WriteLine(client.GetNotificationsAsync().GetAwaiter().GetResult().ToJson()); return;
            //Console.WriteLine(client.GetOpenPositionsAsync().GetAwaiter().GetResult().ToJson()); return;
            //Console.WriteLine(client.GetOrderBookAsync("in_ltcusd").GetAwaiter().GetResult().ToJson()); return;
            //Console.WriteLine(client.GetTickersAsync().GetAwaiter().GetResult().ToJson()); return;
            //Console.WriteLine(client.GetOrderFillsAsync(DateTime.Now.AddDays(-5)).GetAwaiter().GetResult().ToJson()); return;
            //Console.WriteLine(client.GetAccountsInfoAsync().GetAwaiter().GetResult().ToJson()); return;
            //Console.WriteLine(client.GetTransfersAsync().GetAwaiter().GetResult().ToJson()); return;
            //Console.WriteLine(client.GetAccountsInfoAsync().GetAwaiter().GetResult().ToJson()); return;
            //Console.WriteLine(client.GetOpenOrdersAsync().GetAwaiter().GetResult().ToJson()); return;
            //Console.WriteLine(client.CancelOrderAsync(null, "a0b441c1).GetAwaiter().GetResult().ToJson()); return;
            //Console.WriteLine(client.CancelAllOrdersAsync("pi_xbtusd").GetAwaiter().GetResult().ToJson()); return;
            //Console.WriteLine(client.CancelAllOrdersAfterAsync(30).GetAwaiter().GetResult().ToJson()); return;

            //var order = client.CreateOrderAsync(Guid.NewGuid().ToString(), OrderType.LimitOrder, "pi_xbtusd", Side.Buy, 35, price).GetAwaiter().GetResult();
            
            //Console.WriteLine(order.ToJson());
            

            //Console.WriteLine(client.GetOpenOrdersAsync().GetAwaiter().GetResult().ToJson());

            Console.WriteLine(client.GetTransfersAsync().GetAwaiter().GetResult().ToJson());
            client.CreateTransferAsync("cash", "fv_xrpxbt", "xbt", 0.00001m).GetAwaiter().GetResult();
            
            */
        }
    }
}
