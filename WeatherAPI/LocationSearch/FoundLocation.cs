using System.Text.Json.Serialization;
using WeatherAPI.Common.Base;

namespace WeatherAPI.LocationSearch
{
    public class FoundLocation : LocationBase
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
