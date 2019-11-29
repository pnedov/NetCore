using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using MoviesBox.SharedLogic;
using MoviesBox.Services.Helpers;

namespace MoviesBox.Services.Model
{
  [Serializable]
  public class MoviesResponse : IMovie
  {
    [JsonProperty("Search", ItemConverterType = typeof(ConcreteConverter<ISearch, SearchResponse>))]
    public List<ISearch> Search { get; set; }
    [JsonProperty("totalResults")]
    public string TotalResults { get; set; }
    [JsonProperty("Response")]
    public string Response { get; set; }
    public bool Success { get; set; }
  }
}
