﻿using MoviesBox.SharedLogic;
using System;
using System.Collections.Generic;

namespace MoviesBox.DB
{
  public class DbMovie : IMovieFullInfo
  {
    public int moveiID { get; set; }
    public string ImdbID { get; set; }
    public string Title { get; set; }
    public string Year { get; set; }
    public string Rated { get; set; }
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
    public int Metascore { get; set; }
    public double ImdbRating { get; set; }
    public int ImdbVotes { get; set; }
    public string Type { get; set; }
    public DateTime ReleaseDateDvd { get; set; }
    public string BoxOffice { get; set; }
    public string Production { get; set; }
    public string Website { get; set; }
    public bool Response { get; set; }
    public List<IRating> Ratings { get; set; }
  }
}
