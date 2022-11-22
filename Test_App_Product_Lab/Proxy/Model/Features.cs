using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
