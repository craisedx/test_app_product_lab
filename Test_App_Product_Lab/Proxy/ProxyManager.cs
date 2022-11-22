using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Test_App_Product_Lab.Constants;

namespace Test_App_Product_Lab.Proxy
{
    public class ProxyManager
    {
        public string Host { get; set; }
        public int Port { get; set; }
        private readonly int _countTryToConnectProxy;
        public ProxyManager()
        {
            _countTryToConnectProxy = ProxyApiInfoConstants.CountTryToConnectProxy;
        }
        
        public ProxyManager(string host, int port) 
            : base()
        {
            Host = host;
            Port = port;
        }

        /// <summary>
        /// Set a proxy on <see cref="HttpClient"/>.
        /// <para>For testing purposes, if it is impossible to install a proxy, the request is generated without a proxy.</para>
        /// </summary>
        /// <returns>HTTP client with proxy.</returns>
        public async Task<HttpClient> SetProxy()
        {
            var proxy = await GetProxy();

            return proxy != null ? new HttpClient(new HttpClientHandler { Proxy = proxy }) : new HttpClient();
        }


        /// <summary>
        /// Got a <see cref="WebProxy"/>.
        /// <para>For testing purposes, if it is impossible to install a proxy after three attempts, null is returned.</para>
        /// </summary>
        /// <returns>Web proxy object.</returns>
        private async Task<WebProxy> GetProxy()
        {
            if(!string.IsNullOrEmpty(Host) && Port != 0)
            {
                if (IsActiveProxy(Host, Port))
                {
                    return new WebProxy(Host, Port) { BypassProxyOnLocal = false };
                }
            }

            for (var i = 0; i < _countTryToConnectProxy; i++)
            {
                var isSetProxy = await SetProxyFromApi();

                if (isSetProxy) return new WebProxy(Host, Port) { BypassProxyOnLocal = false };
            }

            return null;
        }

        /// <summary>
        /// Check if the proxy server is working.
        /// </summary>
        /// <param name="address">Proxy address.</param>
        /// <param name="port">Proxy port.</param>
        /// <returns>Active proxy or not.</returns>
        private static bool IsActiveProxy(string address, int port)
        {
            var webProxy = new WebProxy(address, port)
            {
                BypassProxyOnLocal = false,
            };
            var httpClientHandler = new HttpClientHandler
            {
                Proxy = webProxy,
            };
            var client = new HttpClient(httpClientHandler);

            var requests = new[]
            {
                new HttpRequestMessage(){ Method = HttpMethod.Get, RequestUri = new Uri(ProxyApiInfoConstants.ProxyCheckGoogleUrl)},
                new HttpRequestMessage(){ Method = HttpMethod.Get, RequestUri = new Uri(ProxyApiInfoConstants.ProxyCheckYandexUrl)},
                new HttpRequestMessage(){ Method = HttpMethod.Get, RequestUri = new Uri(ProxyApiInfoConstants.ProxyCheckMozillaUrl)},
            };

            foreach (var item in requests)
            {
                try
                {
                    using (var response = client.Send(item))
                    {
                        response.EnsureSuccessStatusCode();
                        if (response.StatusCode == HttpStatusCode.OK) return true;
                    }
                }
                catch (Exception) 
                {

                }
            }

            return false;
        }

        /// <summary>
        /// Getting and setting a proxy from the request Api.
        /// </summary>
        /// <returns>Valid proxy or not.</returns>
        private async Task<bool> SetProxyFromApi()
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(ProxyApiInfoConstants.Url),
                Headers =
                {
                    { ProxyApiInfoConstants.FirstHeaderKey, ProxyApiInfoConstants.FirstHeaderValue },
                    { ProxyApiInfoConstants.SecondHeaderKey, ProxyApiInfoConstants.SecondHeaderValue },
                },
            };

            var stringObj = await HttpSender.SendRequestAsync(client, request);

            if(string.IsNullOrEmpty(stringObj)) return false;

            try
            {
                var objProxy = JsonConvert.DeserializeObject<Model.ProxyFullInfo>(stringObj);

                Host = objProxy.ProxyInfo.Address;
                Port = objProxy.ProxyInfo.Port;

                return IsActiveProxy(objProxy.ProxyInfo.Address, objProxy.ProxyInfo.Port);
            }
            catch (Exception)
            {

            }

            return false;
        }
    }
}
