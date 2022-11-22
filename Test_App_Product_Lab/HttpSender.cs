using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Test_App_Product_Lab.Constants;

namespace Test_App_Product_Lab
{
    public class HttpSender
    {
        public HttpSender()
        {
        }

        /// <summary>
        /// Send an HTTP request as an asynchronous operation.
        /// </summary>
        /// <param name="client">Provides a base class for sending Http requests.</param>
        /// <param name="requestMessage">Represents a HTTP requets message.</param>
        /// <returns>HTTP string response.</returns>
        public static async Task<string> SendRequestAsync(HttpClient client, HttpRequestMessage requestMessage)
        {
            try
            {
                using (var response = await client.SendAsync(requestMessage))
                {
                    response.EnsureSuccessStatusCode(); 
                    var strObj = await response.Content.ReadAsStringAsync();

                    return strObj;
                }
            }
            catch (HttpRequestException)
            {
                Console.WriteLine(ExceptionConstants.RequestUnsuccessful);
            }
            catch (Exception)
            {
                
            }

            return null;
        }
    }
}
