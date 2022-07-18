using System.Text.Json.Serialization;
using WeatherAPI.Common;

namespace WeatherAPI.CurrentWeather
{
    public class CurrentWeatherResult
    {
        [JsonPropertyName("location")]
        public WeatherLocation Location { get; set; }

        [JsonPropertyName("current")]
        public CurrentWeather CurrentWeather { get; set; }
    }
}
