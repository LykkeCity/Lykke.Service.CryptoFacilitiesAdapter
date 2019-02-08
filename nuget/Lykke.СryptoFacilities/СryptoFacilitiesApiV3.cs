﻿using System;
using System.Collections.Specialized;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Lykke.СryptoFacilities
{
    public class СryptoFacilitiesApiV3
    {
        private String apiPath;
        private String apiPublicKey;
        private String apiPrivateKey;
        private Boolean checkCertificate;
        private int nonce;

        public СryptoFacilitiesApiV3(String apiPath, String apiPublicKey, String apiPrivateKey, Boolean checkCertificate)
        {
            this.apiPath = apiPath;
            this.apiPublicKey = apiPublicKey;
            this.apiPrivateKey = apiPrivateKey;
            this.checkCertificate = checkCertificate;
            nonce = 0;
        }

        public СryptoFacilitiesApiV3(String apiPath, Boolean checkCertificate) : this(apiPath, null, null, checkCertificate) { }


        #region utility methods
        // Signs a message
        private String signMessage(String endpoint, String nonce, String postData)
        {
            // Step 1: concatenate postData, nonce + endpoint
            var message = postData + nonce + endpoint;

            //Step 2: hash the result of step 1 with SHA256
            var hash256 = new SHA256Managed();
            var hash = hash256.ComputeHash(Encoding.UTF8.GetBytes(message));

            //step 3: base64 decode apiPrivateKey
            var secretDecoded = (System.Convert.FromBase64String(apiPrivateKey));

            //step 4: use result of step 3 to hash the resultof step 2 with HMAC-SHA512
            var hmacsha512 = new HMACSHA512(secretDecoded);
            var hash2 = hmacsha512.ComputeHash(hash);

            //step 5: base64 encode the result of step 4 and return
            return System.Convert.ToBase64String(hash2);

        }

        // Returns a unique nonce
        private String createNonce()
        {
            nonce += 1;
            long timestamp = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds);
            return timestamp.ToString() + nonce.ToString("D4");
        }

        // Sends an HTTP request
        private string makeRequest(String requestMethod, String endpoint, String postUrl, String postBody)
        {
            if (!checkCertificate)
            {
                ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            }
            using (var client = new WebClient())
            {
                var url = apiPath + endpoint + "?" + postUrl;

                //create authentication headers
                if (apiPublicKey != null && apiPrivateKey != null)
                {
                    var nonce = createNonce();
                    var postData = postUrl + postBody;
                    var signature = signMessage(endpoint, nonce, postData);
                    client.Headers.Add("APIKey", apiPublicKey);
                    client.Headers.Add("Nonce", nonce);
                    client.Headers.Add("Authent", signature);
                }

                if (requestMethod == "POST" && postBody.Length > 0)
                {
                    NameValueCollection parameters = new NameValueCollection();
                    String[] bodyArray = postBody.Split('&');
                    foreach (String pair in bodyArray)
                    {
                        String[] splitPair = pair.Split('=');
                        parameters.Add(splitPair[0], splitPair[1]);
                    }

                    var response = client.UploadValues(url, "POST", parameters);
                    return Encoding.UTF8.GetString(response);
                }
                else
                {
                    return client.DownloadString(url);
                }
            }
        }

        private String makeRequest(String requestMethod, String endpoint)
        {
            return makeRequest(requestMethod, endpoint, String.Empty, String.Empty);
        }

        private static void CheckError(BaseResponce data)
        {
            if (data.Result != "success")
                throw new СryptoАacilitiesException(data.Error);
        }
        #endregion


        #region public endpoints
        // Returns all instruments with specifications
        public string GetInstruments()
        {
            var endpoint = "/api/v3/instruments";
            var json = makeRequest("GET", endpoint);
            return json;
        }


        // Returns market data for all instruments
        public Task<TickerResponce> GetTickersAsync()
        {
            var endpoint = "/api/v3/tickers";
            var json = makeRequest("GET", endpoint);
            var data = json.DeserializeJson<TickerResponce>();
            CheckError(data);

            return Task.FromResult(data);
        }

        // Returns the entire order book for a futures
        public String getOrderBook(String symbol)
        {
            var endpoint = "/api/v3/orderbook";
            var postUrl = "symbol=" + symbol;
            return makeRequest("GET", endpoint, postUrl, String.Empty);
        }

        // Returns historical data for futures and indices
        public String getHistory(String symbol, DateTime lastTime)
        {
            var endpoint = "/api/v3/history";
            var postUrl = "symbol=" + symbol + "&lastTime=" + lastTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            return makeRequest("GET", endpoint, postUrl, String.Empty);
        }

        // Returns historical data for futures and indices
        public String getHistory(String symbol)
        {
            var endpoint = "/api/v3/history";
            var postUrl = "symbol=" + symbol;
            return makeRequest("GET", endpoint, postUrl, String.Empty);
        }
        #endregion

        #region private endpoints

        // Returns key account information
        // Deprecated because it returns info about the Futures margin account only
        [Obsolete("getAccount is deprecated, please use getAccounts instead.")]
        private String getAccount()
        {
            var endpoint = "/api/v3/account";
            return makeRequest("GET", endpoint);
        }

        // Returns key account information
        public Task<AccountInfoResponce> GetAccountsAsync()
        {
            var endpoint = "/api/v3/accounts";
            var json = makeRequest("GET", endpoint);
            var data = json.DeserializeJson<AccountInfoResponce>();
            CheckError(data);
            return Task.FromResult(data);
        }

        // Places an order
        public String sendOrder(String orderType, String symbol, String side, Decimal size, Decimal limitPrice, Decimal stopPrice = 0M)
        {
            var endpoint = "/api/v3/sendorder";
            String postBody;
            if (orderType.Equals("lmt"))
            {
                postBody = String.Format("orderType=lmt&symbol={0}&side={1}&size={2}&limitPrice={3}", symbol, side, size, limitPrice);
            }
            else if (orderType.Equals("stp"))
            {
                postBody = String.Format("orderType=stp&symbol={0}&side={1}&size={2}&limitPrice={3}&stopPrice={4}", symbol, side, size, limitPrice, stopPrice);
            }
            else
            {
                postBody = String.Empty;
            }

            return makeRequest("POST", endpoint, String.Empty, postBody);
        }

        // Cancels an order
        public String cancelOrder(String orderId)
        {
            var endpoint = "/api/v3/cancelorder";
            var postBody = "order_id=" + orderId;
            return makeRequest("POST", endpoint, String.Empty, postBody);
        }

        // Cancels all orders
        public String cancelAllOrders()
        {
            var endpoint = "/api/v3/cancelallorders";
            return makeRequest("POST", endpoint);
        }

        // Places or cancels orders in batch
        public String sendBatchOrder(String jsonElement)
        {
            var endpoint = "/api/v3/batchorder";
            var postBody = "json=" + jsonElement;
            return makeRequest("POST", endpoint, String.Empty, postBody);
        }

        // Returns all open orders
        public String getOpenOrders()
        {
            var endpoint = "/api/v3/openorders";
            return makeRequest("GET", endpoint);
        }

        // Returns filled orders
        public String getFills(DateTime lastFillTime)
        {
            var endpoint = "/api/v3/fills";
            var postUrl = "lastFillTime=" + lastFillTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            return makeRequest("GET", endpoint, postUrl, String.Empty);
        }

        // Returns filled orders
        public String getFills()
        {
            var endpoint = "/api/v3/fills";
            return makeRequest("GET", endpoint, String.Empty, String.Empty);
        }

        // Returns all open positions
        public Task<OpenPositionsResponce> GetOpenPositionsAsync()
        {
            var endpoint = "/api/v3/openpositions";
            var json = makeRequest("GET", endpoint);
            var data = json.DeserializeJson<OpenPositionsResponce>();
            CheckError(data);
            return Task.FromResult(data);
        }

        // Returns the platform noticiations
        public String getNotifications()
        {
            var endpoint = "/api/v3/notifications";
            return makeRequest("GET", endpoint);
        }

        // Sends an xbt witdrawal request
        public String sendWithdrawal(String targetAddress, String currency, Decimal amount)
        {
            var endpoint = "/api/v3/withdrawal";
            var postBody = String.Format("targetAddress={0}&currency={1}&amount={2}", targetAddress, currency, amount);
            return makeRequest("POST", endpoint, String.Empty, postBody);
        }

        // Returns xbt transfers
        public String getTransfers(DateTime lastTransferTime)
        {
            var endpoint = "/api/v3/transfers";
            var postUrl = "lastTransferTime=" + lastTransferTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            return makeRequest("GET", endpoint, postUrl, String.Empty);
        }

        // Returns xbt transfers
        public String getTransfers()
        {
            var endpoint = "/api/v3/transfers";
            return makeRequest("GET", endpoint);
        }

        #endregion
    }
}