using Sports.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sports.Services
{
    public class NavigationInfoJsonConverter : JsonConverter<NavigationInfo>
    {
        public override NavigationInfo? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException();

            var navInfo = new NavigationInfo();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    return navInfo;

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string propertyName = reader.GetString()!;
                    reader.Read();

                    switch (propertyName)
                    {
                        case "key":
                            navInfo.key = reader.GetInt32();
                            break;
                        case "value":
                            if (reader.TokenType == JsonTokenType.String)
                            {
                                navInfo.value = reader.GetString();
                            }
                            else if (reader.TokenType == JsonTokenType.StartObject)
                            {
                                // Optionally, you can handle object-to-string conversion here
                                using (var doc = JsonDocument.ParseValue(ref reader))
                                {
                                    navInfo.value = doc.RootElement.GetRawText();
                                }
                            }
                            else if (reader.TokenType == JsonTokenType.Null)
                            {
                                navInfo.value = null;
                            }
                            else
                            {
                                throw new JsonException("Unexpected token for 'value'");
                            }
                            break;
                        case "has_standings":
                            navInfo.has_standings = reader.TokenType == JsonTokenType.Null ? (bool?)null : reader.GetBoolean();
                            break;
                        case "is_knockout":
                            navInfo.is_knockout = reader.TokenType == JsonTokenType.Null ? (bool?)null : reader.GetBoolean();
                            break;
                        default:
                            reader.Skip();
                            break;
                    }
                }
            }

            throw new JsonException("Incomplete JSON object for NavigationInfo");
        }

        public override void Write(Utf8JsonWriter writer, NavigationInfo value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteNumber("key", value.key);
            writer.WritePropertyName("value");
            if (value.value != null)
                writer.WriteStringValue(value.value);
            else
                writer.WriteNullValue();
            if (value.has_standings.HasValue)
                writer.WriteBoolean("has_standings", value.has_standings.Value);
            else
                writer.WriteNull("has_standings");
            if (value.is_knockout.HasValue)
                writer.WriteBoolean("is_knockout", value.is_knockout.Value);
            else
                writer.WriteNull("is_knockout");
            writer.WriteEndObject();
        }
    }
}