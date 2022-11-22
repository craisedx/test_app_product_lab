using System.Collections.Generic;
using Newtonsoft.Json;

namespace Test_App_Product_Lab.Models
{
    public class AllProduct
    {
        [JsonProperty("products")]
        public List<ProductInfo> ProductInfos { get; set; }
    }
}
