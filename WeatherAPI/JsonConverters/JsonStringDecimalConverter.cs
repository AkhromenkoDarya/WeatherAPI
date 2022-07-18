using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeatherAPI.JsonConverters
{
    internal class JsonStringDecimalConverter : JsonConverter<decimal>
    {
        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options) =>
            reader.GetString() is not { Length: > 0 } stringValue
            || !decimal.TryParse(stringValue, NumberStyles.Any, CultureInfo.InvariantCulture, 
                out decimal number)
                ? default
                : number;

        public override void Write(Utf8JsonWriter writer, decimal value,
            JsonSerializerOptions options) => writer.WriteStringValue(value
            .ToString(CultureInfo.InvariantCulture));
    }
}
