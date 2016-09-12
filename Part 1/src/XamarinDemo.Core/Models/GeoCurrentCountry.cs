using Newtonsoft.Json;

namespace XamarinDemo.Core
{
    public class GeoCurrentCountry
    {
        [JsonProperty(PropertyName = "results")]
        public GeoResult[] Result { get; set; }
    }
}