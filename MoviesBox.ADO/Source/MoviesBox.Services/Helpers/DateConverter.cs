using Newtonsoft.Json;
using System;
using System.Globalization;

namespace MoviesBox.Services.Helpers
{
  /// <summary>
  /// DateTime converter custom class
  /// </summary>
  public class DateConverter : JsonConverter
  {

    public override bool CanWrite { get { return false; } }

    public override bool CanConvert(Type objectType)
    {
      return (objectType == typeof(DateTime) || objectType == typeof(DateTime?));
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      string rawDate = (string)reader.Value;

      try
      {
        var dateResult = DateTime.ParseExact(rawDate, "dd MMM yyyy", CultureInfo.InvariantCulture);
        return dateResult.Date;
      }
      catch
      {
        return (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
      }
    }
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      writer.WriteValue(value);
    }
  }
}
