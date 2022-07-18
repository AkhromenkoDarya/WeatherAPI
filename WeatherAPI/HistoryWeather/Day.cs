using System.Text.Json.Serialization;
using WeatherAPI.Common;

namespace WeatherAPI.HistoryWeather
{
    public class Day
    {
        [JsonPropertyName("maxtemp_c")]
        public decimal MaximumTemperatureInCelsius { get; set; }

        [JsonPropertyName("maxtemp_f")]
        public decimal MaximumTemperatureInFahrenheit { get; set; }

        [JsonPropertyName("mintemp_c")]
        public decimal MinimumTemperatureInCelsius { get; set; }

        [JsonPropertyName("mintemp_f")]
        public decimal MinimumTemperatureInFahrenheit { get; set; }

        [JsonPropertyName("avgremp_c")]
        public decimal AverageTemperatureInCelsius { get; set; }

        [JsonPropertyName("avgtemp_f")]
        public decimal AverageTemperatureInFahrenheit { get; set; }

        [JsonPropertyName("maxwind_mph")]
        public decimal MaximumWindSpeedInMilesPerHour { get; set; }

        [JsonPropertyName("maxwind_kph")]
        public decimal MaximumWindSpeedInKilometerPerHour { get; set; }

        [JsonPropertyName("totalprecip_mm")]
        public decimal TotalPrecipitationInMillimeter { get; set; }

        [JsonPropertyName("totalprecip_in")]
        public decimal TotalPrecipitationInInches { get; set; }

        [JsonPropertyName("avgvis_km")]
        public decimal AverageVisibilityInKilometer { get; set; }

        [JsonPropertyName("avgvis_miles")]
        public decimal AverageVisibilityInMiles { get; set; }

        [JsonPropertyName("avghumidity")]
        public decimal AverageHumidity { get; set; }

        [JsonPropertyName("condition")]
        public WeatherCondition Condition { get; set; }

        [JsonPropertyName("uv")]
        public decimal UltraVioletIndex { get; set; }
    }
}