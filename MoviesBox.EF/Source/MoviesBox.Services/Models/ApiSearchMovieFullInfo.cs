using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using MoviesBox.Services.Converters;
using System.ComponentModel.DataAnnotations;

namespace MoviesBox.Services.Model
{
  [Serializable]
  public class ApiMovieFullInfo
  {
    [JsonProperty("Title")]
    public string Title { get; set; }

    [JsonProperty("Year")]
    public string Year { get; set; }

    [JsonProperty("Rated")]
    public string Rated { get; set; }

    [JsonProperty("Released")]
    [JsonConverter(typeof(DateConverter))]
    [Display(Name = "Date Release")]
    public DateTime Released { get; set; }

    [JsonProperty("Runtime")]
    public string Runtime { get; set; }

    [JsonProperty("Genre")]
    public string Genre { get; set; }

    [JsonProperty("Director")]
    public string Director { get; set; }

    [JsonProperty("Writer")]
    public string Writer { get; set; }

    [JsonProperty("Actors")]
    public string Actors { get; set; }

    [JsonProperty("Plot")]
    public string Plot { get; set; }

    [JsonProperty("Language")]
    public string Language { get; set; }

    [JsonProperty("Country")]
    public string Country { get; set; }

    [JsonProperty("Awards")]
    public string Awards { get; set; }

    [JsonProperty("Poster")]
    public string Poster { get; set; }

    [JsonProperty("Ratings")]
    public List<ApiRating> Ratings { get; set; }

    [JsonProperty("Metascore")]
    [JsonConverter(typeof(StringToIntntConverter))] 
    public int Metascore { get; set; }

    [JsonProperty("ImdbRating")]
    public float ImdbRating { get; set; }

    [JsonProperty("imdbVotes")]
    [JsonConverter(typeof(StringToIntntConverter))]
    public int ImdbVotes { get; set; }

    [JsonProperty("imdbID")]
    public string ImdbID { get; set; }

    [JsonProperty("Type")]
    public string Type { get; set; }

    [JsonProperty("DVD")]
    [JsonConverter(typeof(DateConverter))]
    [Display(Name = "DVD Release")]
    public DateTime ReleaseDateDvd { get; set; }

    [JsonProperty("BoxOffice")]
    public string BoxOffice { get; set; }

    [JsonProperty("Production")]
    public string Production { get; set; }

    [JsonProperty("Website")]
    public string Website { get; set; }

    [JsonProperty("Response")]
    public bool Response { get; set; }
  }
}
