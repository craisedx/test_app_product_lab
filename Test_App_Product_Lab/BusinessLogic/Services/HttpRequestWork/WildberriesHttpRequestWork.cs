﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Test_App_Product_Lab.Models;
using Test_App_Product_Lab.Proxy;

namespace Test_App_Product_Lab.BusinessLogic.Services.HttpRequestWork
{
    public class WildberriesHttpRequestWork
    {
        private readonly ProxyManager _proxyManager;

        /// <summary>
        /// Initializes a new instance of <see cref="WildberriesHttpRequestWork"/> class.
        /// </summary>
        /// <param name="proxyManager">Object proxy manager.</param>
        public WildberriesHttpRequestWork(ProxyManager proxyManager)
        {
            _proxyManager = proxyManager;
        }

        /// <summary>
        /// Converts response string to a list of products.
        /// </summary>
        /// <param name="stringResponce">Json string object.</param>
        /// <returns>List of products.</returns>
        public async Task<AllProductData> GetProductsWbByQueryAsync(string stringResponce)
        {
            var resObj = await RequestBySearchName(stringResponce);

            if (string.IsNullOrEmpty(resObj)) return null;

            try
            {
                var objWbProducts = JsonConvert.DeserializeObject<AllProductData>(resObj);

                return objWbProducts;
            }
            catch (Exception)
            {

            }

            return null;
        }

        /// <summary>
        /// Get an object from a request.
        /// </summary>
        /// <param name="name">The parameter by which the search will be performed.</param>
        /// <returns>String response.</returns>
        private async Task<string> RequestBySearchName(string name)
        {
            var client = await _proxyManager.SetProxy();

            var url =
                  @$"https://search.wb.ru/exactmatch/ru/common/v4/search?appType=1&couponsGeo=12,3,18,15,21&curr=rub&dest=-1029256,-102269,-2162196,-1257786&emp=0&lang=ru&locale=ru&pricemarginCoeff=1.0&query={name}&reg=0&regions=80,64,83,4,38,33,70,82,69,68,86,75,30,40,48,1,22,66,31,71&resultset=catalog&sort=popular&spp=0&suppressSpellcheck=false";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
            };

            var responceString = await HttpSender.SendRequestAsync(client, request);

            return responceString;
        }

    }
}
