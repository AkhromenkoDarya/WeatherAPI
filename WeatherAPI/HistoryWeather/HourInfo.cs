using System;
using System.Text.Json.Serialization;
using WeatherAPI.Common.Base;
using WeatherAPI.JsonConverters;

namespace WeatherAPI.HistoryWeather
{
    public class HourInfo : MainWeatherCharacteristics
    {
        [JsonPropertyName("time_epoch")]
        public long TimeEpoch { get; set; }

        [JsonPropertyName("time")]
        [JsonConverter(typeof(JsonStringShortDateTimeConverter))]
        public DateTime Time { get; set; }

        [JsonPropertyName("windchill_c")]
        public decimal WindchillC { get; set; }

        [JsonPropertyName("windchill_f")]
        public decimal WindchillF { get; set; }

        [JsonPropertyName("heatindex_c")]
        public decimal HeatindexC { get; set; }

        [JsonPropertyName("heatindex_f")]
        public decimal HeatindexF { get; set; }

        [JsonPropertyName("dewpoint_c")]
        public decimal DewpointC { get; set; }

        [JsonPropertyName("dewpoint_f")]
        public decimal DewpointF { get; set; }

        [JsonPropertyName("will_it_rain")]
        public decimal WillItRain { get; set; }

        [JsonPropertyName("chance_of_rain")]
        public decimal ChanceOfRain { get; set; }

        [JsonPropertyName("will_it_snow")]
        public decimal WillItSnow { get; set; }

        [JsonPropertyName("chance_of_snow")]
        public int ChanceOfSnow { get; set; }
    }
}