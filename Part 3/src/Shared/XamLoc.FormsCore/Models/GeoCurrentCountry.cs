using Newtonsoft.Json;

namespace XamLoc.FormsCore
{
    public class GeoCurrentCountry
    {
        [JsonProperty(PropertyName = "results")]
        public GeoResult[] Result { get; set; }
    }
}