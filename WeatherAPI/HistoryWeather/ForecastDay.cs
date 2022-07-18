using System;
using System.Text.Json.Serialization;
using WeatherAPI.JsonConverters;

namespace WeatherAPI.HistoryWeather
{
    public class ForecastDay
    {
        [JsonPropertyName("date")]
        [JsonConverter(typeof(JsonStringShortDateConverter))]
        public DateTime Date { get; set; }

        [JsonPropertyName("date_epoch")]
        public long DateEpoch { get; set; }

        [JsonPropertyName("day")]
        public Day Day { get; set; }

        [JsonPropertyName("astro")]
        public AstronomicalInfo Astro { get; set; }

        [JsonPropertyName("hour")]
        public HourInfo[] Hour { get; set; }
    }
}