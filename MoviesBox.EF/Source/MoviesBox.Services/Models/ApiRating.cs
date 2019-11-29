using System;
using Newtonsoft.Json;

namespace MoviesBox.Services.Model
{
  [Serializable]
  public class ApiRating 
  {
    [JsonProperty("Source")]
    public string Source { get; set; }

    [JsonProperty("Value")]
    public string Value { get; set; }
  }
}