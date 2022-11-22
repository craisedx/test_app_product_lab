using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_App_Product_Lab.Proxy.Model
{
    public class ProxyInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("host")]
        public string Address { get; set; }
        
        [JsonProperty("port")]
        public int Port { get; set; }

        [JsonProperty("expires_at")]
        public DateTime ExpiresAt { get; set; }

        [JsonProperty("whitelisted_ips")]
        public List<string> WhiteListedIps { get; set; }

        [JsonProperty("features")]
        public Features Features { get; set; }
        
        [JsonProperty("visibility")]
        public Visibility Visibility { get; set; }
    }
}
