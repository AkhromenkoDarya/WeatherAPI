using System;
using System.Text.Json.Serialization;
using WeatherAPI.Common.Base;
using WeatherAPI.JsonConverters;

namespace WeatherAPI.CurrentWeather
{
    public class CurrentWeather : MainWeatherCharacteristics
    {
        [JsonPropertyName("last_updated")]
        [JsonConverter(typeof(JsonStringShortDateTime24HourConverter))]
        public DateTime LastUpdated { get; set; }

        [JsonPropertyName("last_updated_epoch")]
        public long LastUpdatedEpoch { get; set; }

        [JsonPropertyName("uv")]
        public decimal UltraVioletIndex { get; set; }
    }
}