using System.Text.Json.Serialization;

namespace WeatherAPI.Common
{
    public class WeatherCondition
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("code")]
        public int Code { get; set; }
    }
}