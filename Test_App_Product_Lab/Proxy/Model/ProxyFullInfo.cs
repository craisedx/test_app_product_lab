using Newtonsoft.Json;

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
