using Newtonsoft.Json;

namespace XamLoc.MVX.Core.Models
{
    public class GeoAdress
    {
        [JsonProperty(PropertyName = "long_name")]
        public string LongName { get; set; }

        [JsonProperty(PropertyName = "types")]
        public string[] Types { get; set; }
    }
}