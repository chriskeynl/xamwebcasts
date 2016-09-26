using Newtonsoft.Json;

namespace XamLoc.MVX.Core.Models
{
    public class GeoResult
    {
        [JsonProperty(PropertyName = "address_components")]
        public GeoAdress[] Adresses { get; set; }
    }
}