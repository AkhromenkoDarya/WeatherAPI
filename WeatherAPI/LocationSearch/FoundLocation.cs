using System.Text.Json.Serialization;
using WeatherAPI.Common.Base;
using WeatherAPI.JsonConverters;

namespace WeatherAPI.LocationSearch
{
    public class FoundLocation : LocationBase
    {
        [JsonPropertyName("id")]
        [JsonConverter(typeof(JsonLongStringConverter))]
        public string Id { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
