using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeatherAPI.JsonConverters
{
    internal class JsonStringShortTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, 
            JsonSerializerOptions options) =>
            reader.GetString() is not { Length: 8 } stringValue
            || stringValue.Split(' ') is not { Length: 2 }
            || stringValue.Split(':') is not { Length: 2 }
            || !DateTime.TryParseExact(stringValue, "hh:mm tt", CultureInfo.InvariantCulture, 
                DateTimeStyles.None, out DateTime time)
                ? default
                : time;

        public override void Write(Utf8JsonWriter writer, DateTime value, 
            JsonSerializerOptions options) => writer.WriteStringValue(value.ToString("hh:mm tt", 
            CultureInfo.InvariantCulture));
    }
}
