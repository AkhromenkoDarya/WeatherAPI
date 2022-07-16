using System.Text.Json.Serialization;

namespace WeatherAPI.Current
{
    public class CurrentWeather
    {
        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("current")]
        public WeatherAPI.Current.Current Current { get; set; }
    }
}
