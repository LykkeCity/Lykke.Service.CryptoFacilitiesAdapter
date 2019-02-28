using System;
using System.Threading.Tasks;
using Common;
using Common.Log;
using Lykke.Common.Log;
using Lykke.CryptoFacilities;
using Lykke.CryptoFacilities.WebSockets;
using Lykke.CryptoFacilities.WebSockets.FeedMessages;
using Lykke.Logs;
using Lykke.Logs.Loggers.LykkeConsole;

namespace Lykke.Service.CryptoFacilitiesAdapter.ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var publicKey = "";
            var privateKey = "";

            using (var logFactory = LogFactory.Create().AddConsole())
            {
                var log = logFactory.CreateLog(new Program());
                try
                {
                    CheckRestResponseAsync(
                            publicKey,
                            privateKey,
                            logFactory,
                            log)
                        .GetAwaiter().GetResult();

                    CheckWebSocketPrivateResponseAsync(
                            publicKey,
                            privateKey,
                            logFactory,
                            log)
                        .GetAwaiter().GetResult();
                }
                catch (Exception e)
                {
                    log.Error(e);
                }
            }
        }

        private static async Task CheckRestResponseAsync(
            string publicKey,
            string privateKey,
            ILogFactory logFactory,
            ILog log)
        {
            var restClient = new CryptoFacilitiesApiV3(
                "https://www.cryptofacilities.com/derivatives",
                publicKey,
                privateKey,
                false,
                logFactory);

            var openPositions = await restClient.GetOpenPositionsAsync();
            log.Info(openPositions.ToJson());
        }

        private static async Task CheckWebSocketPrivateResponseAsync(
            string publicKey,
            string privateKey,
            ILogFactory logFactory,
            ILog log)
        {
            using (var wsClient = new PrivateCryptoFacilitiesConnection<string, OpenPositionsMessage>(
                "wss://www.cryptofacilities.com/ws/v1",
                "open_positions",
                s => HandlerMessageAsync(log, s),
                s => HandlerMessageAsync(log, s),
                privateKey,
                publicKey,
                TimeSpan.FromSeconds(30),
                logFactory))
            {
                await wsClient.Start();

                await Task.Delay(TimeSpan.FromMinutes(1));

                await wsClient.Stop();

                await Task.Delay(TimeSpan.FromMinutes(1));
            }
        }

        private static Task HandlerMessageAsync(ILog log, string m)
        {
            log.Info(m);

            return Task.CompletedTask;
        }

        private static Task HandlerMessageAsync(ILog log, OpenPositionsMessage m)
        {
            log.Info(m.ToJson());

            return Task.CompletedTask;
        }
    }
}
