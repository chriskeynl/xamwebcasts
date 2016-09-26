using Newtonsoft.Json;

namespace XamLoc.MVX.Core.Models
{
    public class GeoCurrentCountry
    {
        [JsonProperty(PropertyName = "results")]
        public GeoResult[] Result { get; set; }
    }
}