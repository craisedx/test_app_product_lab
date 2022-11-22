using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_App_Product_Lab.Proxy.Model
{
    public class ProxyFullInfo
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("proxy")]
        public ProxyInfo ProxyInfo { get; set; }
    }
}
