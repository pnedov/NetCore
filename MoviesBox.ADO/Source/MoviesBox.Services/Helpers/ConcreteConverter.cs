using Newtonsoft.Json;
using System;

namespace MoviesBox.Services.Helpers
{
  /// <summary>
  /// Class manage deserialize collection of interfaces when concrete classes contains other interfaces
  /// </summary>
  /// <typeparam name="IInterface">The type of the interface.</typeparam>
  /// <typeparam name="TConcrete">The type of the concrete.</typeparam>
  public class ConcreteConverter<IInterface, TConcrete> : JsonConverter where TConcrete : IInterface
  {
    public override bool CanConvert(Type objectType)
    {
      return typeof(IInterface) == objectType;
    }

    public override object ReadJson(JsonReader reader,
      Type objectType, object existingValue, JsonSerializer serializer)
    {
      return serializer.Deserialize<TConcrete>(reader);
    }

    public override bool CanWrite { get { return false; } }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      writer.WriteValue(value);
    }
  }

}
