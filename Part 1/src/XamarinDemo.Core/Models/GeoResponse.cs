using Newtonsoft.Json;

namespace XamarinDemo.Core
{
    public class GeoResponse
    {
        [JsonProperty(PropertyName = "results")]
        public GeoResult[] Result { get; set; }
    }
}