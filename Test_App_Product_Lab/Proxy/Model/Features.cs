using Newtonsoft.Json;
using System.Collections.Generic;

namespace Test_App_Product_Lab.Proxy.Model
{
    public class Features
    {
        [JsonProperty("static")]
        public bool IsStatic { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("supported_protocols")]
        public Dictionary<string,bool> SupportedProtocols { get; set; }
    }
}
