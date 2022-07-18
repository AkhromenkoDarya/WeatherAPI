using System;
using System.Text.Json.Serialization;
using WeatherAPI.Common.Base;
using WeatherAPI.JsonConverters;

namespace WeatherAPI.Common
{
    public class WeatherLocation : LocationBase
    {
        [JsonPropertyName("tz_id")]
        public string TimezoneId { get; set; }

        [JsonPropertyName("localtime_epoch")]
        public long LocalTimeEpoch { get; set; }

        [JsonPropertyName("localtime")]
        [JsonConverter(typeof(JsonStringShortDateTime12HourConverter))]
        public DateTime LocalTime { get; set; }
    }
}