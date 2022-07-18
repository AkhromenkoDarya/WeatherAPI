using System.Globalization;
using System.Text.Json.Serialization;

namespace WeatherAPI.Common.Base
{
    public abstract class LocationBase
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("lat")]
        public decimal Latitude { get; set; }

        [JsonPropertyName("lon")]
        public decimal Longitude { get; set; }

        public string Coordinates => $"{Latitude.ToString(CultureInfo.InvariantCulture)}," +
                                     $"{Longitude.ToString(CultureInfo.InvariantCulture)}";
    }
}
