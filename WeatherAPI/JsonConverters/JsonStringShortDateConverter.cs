using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeatherAPI.JsonConverters
{
    internal class JsonStringShortDateConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, 
            JsonSerializerOptions options) =>
            reader.GetString() is not { Length: 10 } stringValue
            || stringValue.Split('-') is not { Length: 3 }
            || !DateTime.TryParseExact(stringValue, "yyyy-MM-dd", 
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date)
                ? default
                : date;

        public override void Write(Utf8JsonWriter writer, DateTime value,
            JsonSerializerOptions options) => writer.WriteStringValue(value.ToString("yyyy-MM-dd", 
            CultureInfo.InvariantCulture));
    }
}
