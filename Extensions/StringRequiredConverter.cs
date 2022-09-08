using Newtonsoft.Json;
using System;

namespace T20.Content.Extensions
{
    public class StringRequiredConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(string);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            => writer.WriteValue(value);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
                throw CreateException($"Expected string value, but found {reader.TokenType}.", reader);

            var value = (string)reader.Value;

            if (string.IsNullOrWhiteSpace(value))
                throw CreateException("Non-empty string required.", reader);

            return serializer.Deserialize(reader, objectType);
        }

        private static Exception CreateException(string message, JsonReader reader)
        {
            var info = (IJsonLineInfo)reader;
            return new JsonSerializationException(
                $"{message} Path '{reader.Path}', line {info.LineNumber}, position {info.LinePosition}.");
        }
    }
}