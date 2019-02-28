using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Log;
using Lykke.Common.Log;
using Lykke.CryptoFacilities.WebSockets.Messages;
using Newtonsoft.Json;

namespace Lykke.CryptoFacilities.WebSockets
{
    public abstract class WebSocketConnection : IDisposable
    {
        private readonly string _baseUri;
        private readonly TimeSpan _timeout;
        private readonly ILog _log;
        private readonly SemaphoreSlim _semaphoreSlim;

        private DateTime? _lastMessageReceiveTime;
        private ClientWebSocket _clientWebSocket;
        private CancellationTokenSource _cancellationTokenSource;

        public WebSocketConnection(
            string baseUri,
            TimeSpan timeout,
            ILogFactory logFactory)
        {
            _baseUri = baseUri;
            _timeout = timeout;
            _log = logFactory.CreateLog(this);

            _semaphoreSlim = new SemaphoreSlim(1, 1);
        }

        public async Task Start()
        {
            await _semaphoreSlim.WaitAsync();

            try
            {
                if (_clientWebSocket == null || _clientWebSocket.State == WebSocketState.None)
                {
                    _log.Info("Connecting...");

                    _clientWebSocket = new ClientWebSocket();
                    _clientWebSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);

                    _cancellationTokenSource = new CancellationTokenSource();

                    try
                    {
                        await _clientWebSocket.ConnectAsync(new Uri(_baseUri), _cancellationTokenSource.Token)
                            .ConfigureAwait(false);

                        if (_clientWebSocket.State != WebSocketState.Open)
                            throw new Exception(
                                $"Invalid socket state after connect attempt: {_clientWebSocket.State}.");

                        Task.Run(async () =>
                            {
                                if (_cancellationTokenSource == null || _cancellationTokenSource.IsCancellationRequested)
                                    return;

                                await HandleMessagesCycleAsync(_cancellationTokenSource.Token);
                            }, _cancellationTokenSource.Token)
                            .ContinueWith(t =>
                            {
                                if (t.IsFaulted)
                                    _log.Error(t.Exception, "Something went wrong in subscription thread.");
                            }, _cancellationTokenSource.Token);
                    }
                    catch (Exception e)
                    {
                        _log.Error(e);
                        throw;
                    }

                    _log.Info("Connected.");

                    try
                    {
                        await Connected();
                    }
                    catch (Exception e)
                    {
                        _log.Error(e);
                    }

                    _lastMessageReceiveTime = DateTime.UtcNow;

                    Task.Run(ConnectionCheck, _cancellationTokenSource.Token)
                        .ContinueWith(t =>
                        {
                            if (t.IsFaulted)
                            {
                                _log.Critical(t.Exception, "Reconnect thread failed.");
                            }
                        }, _cancellationTokenSource.Token);
                }
                else
                {
                    throw new InvalidOperationException("WebSocket already connected.");
                }
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        private async Task ConnectionCheck()
        {
            while (true)
            {
                await Task.Delay(TimeSpan.FromSeconds(10));

                if (DateTime.UtcNow - _lastMessageReceiveTime.Value > _timeout)
                {
                    _log.Warning("Didn't receive any messages for too long, will reconnect...");

                    if (_clientWebSocket != null && _clientWebSocket.State == WebSocketState.Open)
                    {
                        CleanTokenResetTimer();
                        CleanSocket();
                        await NotifyClient();
                    }

                    try
                    {
                        await Start();

                        break;
                    }
                    catch (Exception e)
                    {
                        _log.Error("Error during reconnect attempt. Will retry in some time. Killing active connection.", e);
                        CleanSocket();
                    }
                }

                if (_cancellationTokenSource == null || _cancellationTokenSource.IsCancellationRequested)
                    break;
            }
        }

        public async Task Stop()
        {
            await _semaphoreSlim.WaitAsync();

            try
            {
                _log.Info("Stopping...");

                CleanTokenResetTimer();
                CleanSocket();

                _log.Info("Stopped.");

                await NotifyClient();
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        private async Task NotifyClient()
        {
            try
            {
                await Disconnected();
            }
            catch (Exception e)
            {
                _log.Error(e);
            }
        }

        protected async Task SendMessageAsync(IRequest request, CancellationToken ct = default)
        {
            try
            {
                var jsonStr = JsonConvert.SerializeObject(request);
                var requestSegment = StringToArraySegment(jsonStr);

                await _clientWebSocket.SendAsync(requestSegment, WebSocketMessageType.Text, true, ct);
            }
            catch (Exception e)
            {
                throw new Exception(
                    "Something went wrong while sending a message to the web socket, see InternalException.", e);
            }
        }

        private async Task HandleMessagesCycleAsync(CancellationToken ct)
        {
            while (_clientWebSocket?.State == WebSocketState.Open)
            {
                using (var stream = new MemoryStream(8192))
                {
                    var receiveBuffer = new ArraySegment<byte>(new byte[1024]);
                    try
                    {
                        WebSocketReceiveResult receiveResult;
                        do
                        {
                            receiveResult = await _clientWebSocket.ReceiveAsync(receiveBuffer, ct);

                            await stream.WriteAsync(receiveBuffer.Array, receiveBuffer.Offset, receiveResult.Count, ct);
                        } while (!receiveResult.EndOfMessage);

                        var messageBytes = stream.ToArray();
                        var jsonMessage = Encoding.UTF8.GetString(messageBytes, 0, messageBytes.Length);

                        if (!string.IsNullOrWhiteSpace(jsonMessage))
                        {
                            _lastMessageReceiveTime = DateTime.UtcNow;

                            await HandleNewMessageAsync(jsonMessage);
                        }
                    }
                    catch (Exception e)
                    {
                        if (e.GetType() != typeof(TaskCanceledException))
                            _log.Warning("Error occured during message handling.", e);
                    }
                }
            }
        }

        protected abstract Task HandleNewMessageAsync(string message);

        protected abstract Task Connected();

        protected abstract Task Disconnected();

        private static ArraySegment<byte> StringToArraySegment(string message)
        {
            var messageBytes = Encoding.UTF8.GetBytes(message);
            return new ArraySegment<byte>(messageBytes);
        }

        private void CleanSocket()
        {
            _clientWebSocket?.Abort();
            _clientWebSocket?.Dispose();
            _clientWebSocket = null;
        }

        private void CleanTokenResetTimer()
        {
            _lastMessageReceiveTime = null;

            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }

        public void Dispose()
        {
            CleanTokenResetTimer();
            CleanSocket();
        }
    }
}
