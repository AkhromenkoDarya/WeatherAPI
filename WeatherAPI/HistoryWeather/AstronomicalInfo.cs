using System;
using System.Text.Json.Serialization;
using WeatherAPI.Common.Enums;
using WeatherAPI.JsonConverters;

namespace WeatherAPI.HistoryWeather
{
    public class AstronomicalInfo
    {
        [JsonPropertyName("sunrise")]
        [JsonConverter(typeof(JsonStringShortTimeConverter))]
        public DateTime Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        [JsonConverter(typeof(JsonStringShortTimeConverter))]
        public DateTime Sunset { get; set; }

        [JsonPropertyName("moonrise")]
        [JsonConverter(typeof(JsonStringShortTimeConverter))]
        public DateTime Moonrise { get; set; }

        [JsonPropertyName("moonset")]
        [JsonConverter(typeof(JsonStringShortTimeConverter))]
        public DateTime Moonset { get; set; }

        [JsonPropertyName("moon_phase")]
        public MoonPhaseType MoonPhase { get; set; }

        [JsonPropertyName("moon_illumination")]
        [JsonConverter(typeof(JsonMoonIlluminationConverter))]
        public decimal MoonIllumination { get; set; }
    }
}