using Newtonsoft.Json;

namespace XamarinDemo.Core
{
    public class GeoResult
    {
        [JsonProperty(PropertyName = "address_components")]
        public GeoAdress[] Adresses { get; set; }
    }
}