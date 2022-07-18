using System.Text.Json.Serialization;

namespace WeatherAPI.HistoryWeather
{
    public class Forecast
    {
        [JsonPropertyName("forecastday")]
        public ForecastDay[] ForecastDay { get; set; }
    }
}