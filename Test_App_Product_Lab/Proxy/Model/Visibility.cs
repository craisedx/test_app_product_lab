using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_App_Product_Lab.Proxy.Model
{
    public class Visibility
    {
        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country_iso")]
        public string CountryIso { get; set; }

        [JsonProperty("latitude")]
        public float Latitude { get; set; }

        [JsonProperty("longitude")]
        public float Longitude { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("asn")]
        public string Asn { get; set; }

        [JsonProperty("asn_org")]
        public string AsnOrg { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }
    }
}
