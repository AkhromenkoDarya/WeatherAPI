using System.Text.Json.Serialization;

namespace WeatherAPI.Common.Base
{
    public abstract class MainWeatherCharacteristics
    {
        [JsonPropertyName("temp_c")]
        public decimal TemperatureInCelsius { get; set; }

        [JsonPropertyName("temp_f")]
        public decimal TemperatureInFahrenheit { get; set; }

        [JsonPropertyName("feelslike_c")]
        public decimal FeelsLikeInCelsius { get; set; }

        [JsonPropertyName("feelslike_f")]
        public decimal FeelsLikeInFahrenheit { get; set; }

        [JsonPropertyName("condition")]
        public WeatherCondition Condition { get; set; }

        [JsonPropertyName("wind_mph")]
        public decimal WindInMilesPerHour { get; set; }

        [JsonPropertyName("wind_kph")]
        public decimal WindInKilometerPerHour { get; set; }

        [JsonPropertyName("wind_degree")]
        public int WindDegree { get; set; }

        [JsonPropertyName("wind_dir")]
        public string WindDirection { get; set; }

        [JsonPropertyName("gust_mph")]
        public decimal WindGustInMilesPerHour { get; set; }

        [JsonPropertyName("gust_kph")]
        public decimal WindGustInKilometerPerHour { get; set; }

        [JsonPropertyName("vis_km")]
        public decimal VisibilityInKilometer { get; set; }

        [JsonPropertyName("vis_miles")]
        public decimal VisibilityInMiles { get; set; }

        [JsonPropertyName("pressure_mb")]
        public decimal PressureInMillibars { get; set; }

        [JsonPropertyName("pressure_in")]
        public decimal PressureInInches { get; set; }

        [JsonPropertyName("precip_mm")]
        public decimal PrecipitationAmountInMillimeter { get; set; }

        [JsonPropertyName("precip_in")]
        public decimal PrecipitationAmountInInches { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("cloud")]
        public int CloudCover { get; set; }

        [JsonPropertyName("is_day")]
        public int IsDay { get; set; }
    }
}
