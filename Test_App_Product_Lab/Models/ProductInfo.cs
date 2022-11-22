using Newtonsoft.Json;

namespace Test_App_Product_Lab.Models
{
    public class ProductInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("priceU")]
        public int Price { get; set; }

        [JsonProperty("feedbacks")]
        public int FeedBacks { get; set; }
    }
}