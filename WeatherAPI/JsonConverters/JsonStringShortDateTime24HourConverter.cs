using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeatherAPI.JsonConverters
{
    internal class JsonStringShortDateTime24HourConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options) =>
            reader.GetString() is not { Length: >= 15 } stringValue
            || stringValue.Split(' ') is not { Length: 2 } components
            || components[0].Split('-') is not { Length: 3 }
            || components[1].Split(':') is not { Length: 2 }
            || !DateTime.TryParseExact(stringValue, "yyyy-MM-dd HH:mm", 
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime)
                ? default
                : dateTime;

        public override void Write(Utf8JsonWriter writer, DateTime value, 
            JsonSerializerOptions options) => writer.WriteStringValue(value.ToString(
            "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture));
    }
}
