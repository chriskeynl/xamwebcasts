using Newtonsoft.Json;

namespace XamLoc.FormsCore
{
    public class GeoResponse
    {
        [JsonProperty(PropertyName = "results")]
        public GeoResult[] Result { get; set; }
    }
}