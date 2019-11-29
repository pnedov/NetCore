using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesBox.SharedLogic
{
  public interface IMovieFullInfo 
  {
    string Title { get; set; }
    string Year { get; set; }
    string Rated { get; set; }
    [Display(Name = "Release Date")]
    DateTime Released { get; set; }
    string Runtime { get; set; }
    string Genre { get; set; }
    string Director { get; set; }
    string Writer { get; set; }
    string Actors { get; set; }
    string Plot { get; set; }
    string Language { get; set; }
    string Country { get; set; }
    string Awards { get; set; }
    string Poster { get; set; }
    List<IRating> Ratings { get; set; }
    int Metascore { get; set; }
    [Display(Name = "IMDB Rating")]
    double ImdbRating { get; set; }
    [Display(Name = "IMDB Votes")]
    int ImdbVotes { get; set; }
    [Display(Name = "IMDB Id")]
    string ImdbID { get; set; }
    string Type { get; set; }
    [Display(Name = "DVD Release Date")]
    DateTime ReleaseDateDvd { get; set; }
    [Display(Name = "Box Office")]
    string BoxOffice { get; set; }
    string Production { get; set; }
    string Website { get; set; }
    bool Response { get; set; }
  }
}
