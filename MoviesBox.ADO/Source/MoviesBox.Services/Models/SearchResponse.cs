using System;
using Newtonsoft.Json;
using MoviesBox.SharedLogic;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MoviesBox.Services.Model
{
  [Serializable]
  public class SearchResponse : ISearch
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
}