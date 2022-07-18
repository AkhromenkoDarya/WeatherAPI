using System.Text.Json.Serialization;
using WeatherAPI.Common;

namespace WeatherAPI.HistoryWeather
{
    public class SevenDayWeatherHistory
    {
        [JsonPropertyName("location")]
        public WeatherLocation Location { get; set; }

        [JsonPropertyName("forecast")]
        public Forecast Forecast { get; set; }
    }
}
