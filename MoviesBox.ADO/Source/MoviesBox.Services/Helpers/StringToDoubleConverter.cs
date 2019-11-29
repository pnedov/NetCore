using Newtonsoft.Json;
using System;
using System.Globalization;

namespace MoviesBox.Services.Helpers
{
  /// <summary>
  /// String to double converter custom class
  /// </summary>
  public class StringToDoubleConverter : JsonConverter
  {
    public override bool CanConvert(Type objectType)
    {
      return objectType == typeof(int?);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      if (reader.TokenType == JsonToken.Null)
        return null;
      if (reader.TokenType == JsonToken.Float)
        return reader.Value;

      if (reader.TokenType == JsonToken.String)
      {
        if (string.IsNullOrEmpty((string)reader.Value))
          return null;
        if ((string)reader.Value == "N/A")
          return null;
        double num = 0.0d;
        if (double.TryParse((string)reader.Value, out num))
        {
          return num;
        }
        if (double.TryParse((string)reader.Value, NumberStyles.AllowThousands,
                 CultureInfo.InvariantCulture, out num))
        {
          return num;
        }

        throw new JsonReaderException(string.Format("Expected integer, got {0}", reader.Value));
      }
      throw new JsonReaderException(string.Format("Unexcepted token {0}", reader.TokenType));
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      writer.WriteValue(value);
    }
  }
}
