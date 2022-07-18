using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeatherAPI.JsonConverters
{
    internal class JsonLongStringConverter : JsonConverter<string>
    {
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options) =>
            reader.GetInt64().ToString() is not { Length: > 0 } stringValue
                || stringValue[0] is '0'
                ? string.Empty
                : stringValue;

        public override void Write(Utf8JsonWriter writer, string value,
            JsonSerializerOptions options) =>
            writer.WriteNumberValue(
                !long.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, 
                    out long longValue)
                    ? default
                    : longValue
            );
    }
}
