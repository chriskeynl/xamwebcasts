using Newtonsoft.Json;

namespace XamarinDemo.Core
{
    public class GeoAdress
    {
        [JsonProperty(PropertyName = "long_name")]
        public string LongName { get; set; }

        [JsonProperty(PropertyName = "types")]
        public string[] Types { get; set; }
    }
}