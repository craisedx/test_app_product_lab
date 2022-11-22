using Newtonsoft.Json;

namespace Test_App_Product_Lab.Models
{
    public class AllProductData
    {
        [JsonProperty("data")]
        public AllProduct AppProduct { get; set; }
    }
}
