﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Log;
using Lykke.Common.Log;
using Lykke.СryptoFacilities.Exceptions;
using Lykke.СryptoFacilities.Models.Common;
using Lykke.СryptoFacilities.Models.Request;
using Lykke.СryptoFacilities.Models.Response;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Lykke.СryptoFacilities
{
    public class СryptoFacilitiesClient : ICryptoFacilitiesClient
    {
        private readonly string _apiPath;
        private readonly string _apiPublicKey;
        private readonly string _apiPrivateKey;
        private readonly bool _checkCertificate;
        private int _nonce;

        private ILog _log;

        public СryptoFacilitiesClient(string apiPath, string apiPublicKey, string apiPrivateKey, bool checkCertificate)
        {
            _apiPath = apiPath;
            _apiPublicKey = apiPublicKey;
            _apiPrivateKey = apiPrivateKey;
            _checkCertificate = checkCertificate;
            
            _nonce = 0;
        }

        // Sends an HTTP request
        private async Task<T> MakeRequest<T>(HttpMethod requestMethod, string endpoint, BaseRequestUrl urlData = default(BaseRequestUrl), BaseRequestBody bodyData = default(BaseRequestBody)) where T : BaseResponse
        {
            if (urlData == default(BaseRequestUrl))
                urlData = BaseRequestUrl.Empty();
            
            if(bodyData == default(BaseRequestBody))
                bodyData = BaseRequestBody.Empty();
            
            var requestUrlParams = await urlData.ToUrlParamString();
            var requestBodyParams = await bodyData.ToUrlParamString();
            
            if (!_checkCertificate)
            {
                ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            }
            
            using (var client = new HttpClient())
            {
                var nonce = GetNonce();
                
                var httpRequestMessage = new HttpRequestMessage
                {
                    Method = requestMethod,
                    RequestUri = new Uri(_apiPath + endpoint + "?" + requestUrlParams),
                    Headers = { 
                        { "APIKey", _apiPublicKey },
                        { "Nonce", nonce },
                        { "Authent", SignMessage(endpoint, nonce, requestUrlParams + requestBodyParams) }
                    },
                    Content = new StringContent(JsonConvert.SerializeObject(bodyData))
                };

                var response = await client.SendAsync(httpRequestMessage);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Request to CryptoFacilities resulted in {response.StatusCode.ToString()}");
                }

                var resultString = await response.Content.ReadAsStringAsync();

                var result = resultString.DeserializeJson<T>();
            
                CheckForError(result);

                return result;
            }
        }

        private static void CheckForError(BaseResponse data)
        {
            if (data.Result == "success")
                return;
            
            switch (data.Error)
            {
                case "apiLimitExceeded" : throw new ApiLimitExceededException();
                case "invalidAccount": throw new InvalidAccountException();
                case "invalidAmount" : throw new InvalidAmountException();
                case "insufficientFunds": throw new InsufficientFundsException();
                case "nonceBelowThreshold" : throw new NonceBelowThresholdException();
                case "nonceDuplicate" : throw new NonceDuplicateException();
                default: throw new СryptoFacilitiesException($"Unknown error: {data.Error}");
            }
        }


        #region public endpoints
        
        public async Task<Instrument[]> GetInstrumentsAsync()
        {
            var resp = await MakeRequest<InstrumentsResponse>(HttpMethod.Get, "/api/v3/instruments");

            return resp.Instruments;
        }
        
        public async Task<TickerInfo[]> GetTickersAsync()
        {
            var resp = await MakeRequest<TickerResponse>(HttpMethod.Get, "/api/v3/tickers");

            return resp.Tickers;
        }
        
        public async Task<OrderBook> GetOrderBookAsync(string symbol)
        {
            var urlData = new OrderBookRequestUrl
            {
                Symbol = symbol
            };
            
            var resp = await MakeRequest<OrderBookResponse>(HttpMethod.Get, "/api/v3/orderbook", urlData);

            return resp.OrderBook;
        }
        
        public async Task<HistoryRecord[]> GetHistoryAsync(string symbol, DateTime? lastTime = default(DateTime?))
        {
            var postUrl = new HistoryRequestUrl
            {
                Symbol = symbol,
                LastTime = lastTime
            };
            
            var resp = await MakeRequest<HistoryResponse>(HttpMethod.Get, "/api/v3/history", postUrl);

            return resp.History;
        }
        #endregion

        #region private endpoints

        public async Task<AccountsInfo> GetAccountsInfoAsync()
        {
            var resp = await MakeRequest<GetAccountInfoResponse>(HttpMethod.Get, "/api/v3/accounts");

            return resp.Accounts;
        }

        public async Task CreateTransferAsync(string fromAccount, string toAccount, string unit, decimal amount)
        {
            var request = new CreateTransferRequestUrl
            {
                FromAccount = fromAccount,
                ToAccount = toAccount,
                Unit = unit,
                Amount = amount
            };

            var resp = await MakeRequest<CreateTransferResponse>(HttpMethod.Post, "/api/v3/transfer", request);
        }
        
        public async Task<CreatedOrder> CreateOrderAsync(string id, OrderType type, string symbol, Side side, long size, decimal limitPrice, decimal? stopPrice = default(decimal?))
        {
            if(type == OrderType.StopOrder && !stopPrice.HasValue)
                throw new ArgumentNullException(nameof(stopPrice));

            var request = new CreateOrderRequestUrl
            {
                ClientOrderId = id,
                Type = type,
                Symbol = symbol,
                Side = side,
                Size = size,
                LimitPrice = limitPrice,
                StopPrice = stopPrice
            };

            var resp = await MakeRequest<CreateOrderResponse>(HttpMethod.Post, "/api/v3/sendorder", request);

            return resp.CreatedOrder;
        }

        // Cancels an order
        public async Task<CancelOrderResult> CancelOrderAsync(string orderId, string clientOrderId)
        {
            var request = new CancelOrderRequestUrl
            {
                OrderId = orderId,
                ClientOrderId = clientOrderId
            };
            
            var resp = await MakeRequest<CancelOrderResponse>(HttpMethod.Post, "/api/v3/cancelorder", request);

            return resp.CancellationResult;
        }

        // Cancels all orders
        public async Task<CancelAllOrdersResult> CancelAllOrdersAsync(string symbol = null)
        {
            var request = new CancelAllOrdersRequestUrl
            {
                Symbol = symbol
            };
            
            var resp = await MakeRequest<CancelAllOrdersResponse>(HttpMethod.Post, "/api/v3/cancelallorders", request);

            return resp.CancellationResult;
        }

        // This endpoint returns information on all open orders for all Futures contracts.
        public async Task<OpenOrder[]> GetOpenOrdersAsync()
        {
            var resp = await MakeRequest<GetOpenOrdersResponse>(HttpMethod.Get, "/api/v3/openorders");

            return resp.Orders;
        }

        // This endpoint returns information on filled orders for all futures contracts.
        public async Task<OrderFill[]> GetOrderFillsAsync(DateTime? lastFillTime = default(DateTime?))
        {
            var request = new GetOrderFillsRequestUrl
            {
                LastFillTime = lastFillTime
            };
            
            var resp = await MakeRequest<GetOrderFillsResponse>(HttpMethod.Get, "/api/v3/fills", request);

            return resp.OrderFills;
        }

        // This endpoint returns the size and average entry price of all open positions in Futures contracts. This includes Futures contracts that have matured but have not yet been settled.
        public async Task<OpenPosition[]> GetOpenPositionsAsync()
        {
            var resp = await MakeRequest<OpenPositionsResponse>(HttpMethod.Get, "/api/v3/openpositions");

            return resp.OpenPositions;
        }

        // This endpoint provides the platform's notifications.
        public async Task<Notification[]> GetNotificationsAsync()
        {
            var resp = await MakeRequest<NotificationsResponse>(HttpMethod.Get, "/api/v3/notifications");

            return resp.Notifications;
        }

        // This endpoint returns information on digital asset deposits and withdrawals to and from a CryptoFacilities account.
        public async Task<Transfer[]> GetTransfersAsync(DateTime? lastTransferTime = default(DateTime?))
        {
            var request = new GetTransfersRequestUrl
            {
                LastTransferTime = lastTransferTime
            };
            
            var resp = await MakeRequest<GetTransfersResponse>(HttpMethod.Get, "/api/v3/transfers", request);

            return resp.Transfers;
        }

        #endregion
        
        private string SignMessage(string endpoint, string nonce, string postData)
        {
            // Step 1: concatenate postData, nonce + endpoint
            var message = postData + nonce + endpoint;

            //Step 2: hash the result of step 1 with SHA256
            var hash256 = new SHA256Managed();
            var hash = hash256.ComputeHash(Encoding.UTF8.GetBytes(message));

            //step 3: base64 decode apiPrivateKey
            var secretDecoded = (System.Convert.FromBase64String(_apiPrivateKey));

            //step 4: use result of step 3 to hash the result of step 2 with HMAC-SHA512
            var hmacsha512 = new HMACSHA512(secretDecoded);
            var hash2 = hmacsha512.ComputeHash(hash);

            //step 5: base64 encode the result of step 4 and return
            return System.Convert.ToBase64String(hash2);
        }
        
        private string GetNonce()
        {
            _nonce += 1;
            var timestamp = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds);
            return timestamp + _nonce.ToString("D4");
        }
    }
    
    internal static class RestHelper
    {
        public static async Task<string> ToUrlParamString(this object o)
        {
            var keyValueContent = o.ToKeyValue();

            if (keyValueContent == null)
                return string.Empty;
            
            return string.Join("&",
                keyValueContent.Select(kvp =>
                    string.Format("{0}={1}", kvp.Key, kvp.Value)));
        }

        private static IDictionary<string, string> ToKeyValue(this object metaToken)
        {
            if (metaToken == null)
            {
                return null;
            }

            JToken token = metaToken as JToken;
            if (token == null)
            {
                return ToKeyValue(JObject.FromObject(metaToken));
            }

            if (token.HasValues)
            {
                var contentData = new Dictionary<string, string>();
                foreach (var child in token.Children().ToList())
                {
                    var childContent = child.ToKeyValue();
                    if (childContent != null)
                    {
                        contentData = contentData.Concat(childContent)
                            .ToDictionary(k => k.Key, v => v.Value);
                    }
                }

                return contentData;
            }

            var jValue = token as JValue;
            if (jValue?.Value == null)
            {
                return null;
            }

            var value = jValue?.Type == JTokenType.Date ?
                jValue?.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture) :
                jValue?.ToString(CultureInfo.InvariantCulture);

            return new Dictionary<string, string> { { token.Path, value } };
        }
    }
}
