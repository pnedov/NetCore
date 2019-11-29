using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MoviesBox.Services.Model
{
  [Serializable]
  public class ApiSearch
  {
    [JsonProperty("Title")]
    public string Title { get; set; }
    [JsonProperty("Year")]
    public string Year { get; set; }
    [JsonProperty("imdbID")]
    public string ImdbID { get; set; }
    [JsonProperty("Type")]
    public string Type { get; set; }
    [JsonProperty("Poster")]
    public string Poster { get; set; }
  }

  [Serializable]
  public class ApiMoviesResponse
  {
    [JsonProperty("Search")]
    public List<ApiSearch> Search { get; set; }
    [JsonProperty("totalResults")]
    public string TotalResults { get; set; }
    [JsonProperty("Response")]
    public string Response { get; set; }
    public bool Success { get; set; }
  }
}
