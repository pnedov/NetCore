using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesBox.BL.Model
{
  public class MovieFullInfo
  {
    public string Title { get; set; }
    public string Year { get; set; }
    public string Rated { get; set; }
    [Display(Name = "Release Date")]
    public DateTime Released { get; set; }
    public string Runtime { get; set; }
    public string Genre { get; set; }
    public string Director { get; set; }
    public string Writer { get; set; }
    public string Actors { get; set; }
    public string Plot { get; set; }
    public string Language { get; set; }
    public string Country { get; set; }
    public string Awards { get; set; }
    public string Poster { get; set; }
    public List<MovieRating> Ratings { get; set; }
    public int Metascore { get; set; }
    [Display(Name = "IMDB Rating")]
    public float ImdbRating { get; set; }
    [Display(Name = "IMDB Votes")]
    public int ImdbVotes { get; set; }
    [Display(Name = "IMDB ID")]
    public string ImdbID { get; set; }
    public string Type { get; set; }
    [Display(Name = "DVD Release Date")]
    public DateTime ReleaseDateDvd { get; set; }
    [Display(Name = "Box Office")]
    public string BoxOffice { get; set; }
    public string Production { get; set; }
    public string Website { get; set; }
    public bool Response { get; set; }
  }
}
