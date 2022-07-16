using System.Text.Json.Serialization;

namespace WeatherAPI.Current
{
    public class Current
    {
        [JsonPropertyName("last_updated")]
        public string LastUpdated { get; set; }

        [JsonPropertyName("last_updated_epoch")]
        public long LastUpdatedEpoch { get; set; }

        [JsonPropertyName("temp_c")]
        public decimal TemperatureInCelsius { get; set; }

        [JsonPropertyName("temp_f")]
        public decimal TemperatureInFahrenheit { get; set; }

        [JsonPropertyName("feelslike_c")]
        public decimal FeelsLikeCelsius { get; set; }

        [JsonPropertyName("feelslike_f")]
        public decimal FeelsLikeFahrenheit { get; set; }

        [JsonPropertyName("condition")]
        public Condition Condition { get; set; }

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
        public decimal PrecipitationAmountInMillimeters { get; set; }

        [JsonPropertyName("precip_in")]
        public decimal PrecipitationAmountInInches { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("cloud")]
        public int CloudCover { get; set; }

        [JsonPropertyName("is_day")]
        public int IsDay { get; set; }

        [JsonPropertyName("uv")]
        public decimal UltraVioletIndex { get; set; }
    }
}