using Newtonsoft.Json;

namespace XamLoc.FormsCore
{
    public class GeoResult
    {
        [JsonProperty(PropertyName = "address_components")]
        public GeoAdress[] Adresses { get; set; }
    }
}