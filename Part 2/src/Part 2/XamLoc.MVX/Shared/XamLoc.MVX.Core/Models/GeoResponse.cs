using Newtonsoft.Json;

namespace XamLoc.MVX.Core.Models
{
    public class GeoResponse
    {
        [JsonProperty(PropertyName = "results")]
        public GeoResult[] Result { get; set; }
    }
}