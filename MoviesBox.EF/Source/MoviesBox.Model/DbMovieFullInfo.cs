using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesBox.EFModel
{
  [Table("Movies")]
  public class DbMovieFullInfo
  {
    [AutoMapper.IgnoreMap()]
    [Key]
    [Column("movie_id", TypeName = "int", Order = 0)]
    public int moveiID { get; set; }
    [Column("imdb_id", TypeName = "varchar(30)", Order = 1)]
    public string ImdbID { get; set; }
    [Required]
    [Column("title", TypeName = "varchar(150)", Order = 2)]
    public string Title { get; set; }
    [Column("year", TypeName = "varchar(10)", Order = 3)]
    public string Year { get; set; }
    [Column("rated", TypeName = "varchar(10)", Order = 4)]
    public string Rated { get; set; }
    [Column("released", TypeName = "datetime", Order = 5)]
    public DateTime Released { get; set; }
    [Column("runtime", TypeName = "varchar(50)", Order = 6)]
    public string Runtime { get; set; }
    [Column("genre", TypeName = "varchar(50)", Order = 7)]
    public string Genre { get; set; }
    [Column("director", TypeName = "varchar(150)", Order = 8)]
    public string Director { get; set; }
    [Column("writer", TypeName = "varchar(350)", Order = 9)]
    public string Writer { get; set; }
    [Column("actors", TypeName = "varchar(350)", Order = 10)]
    public string Actors { get; set; }
    [Column("plot", TypeName = "varchar(250)", Order = 11)]
    public string Plot { get; set; }
    [Column("language", TypeName = "varchar(150)", Order = 12)]
    public string Language { get; set; }
    [Column("country", TypeName = "varchar(100)", Order = 13)]
    public string Country { get; set; }
    [Column("awards", TypeName = "varchar(250)", Order = 24)]
    public string Awards { get; set; }
    [Column("poster", TypeName = "varchar(250)", Order = 14)]
    public string Poster { get; set; }

    [Column("metascore", TypeName = "int", Order = 15)]
    public int Metascore { get; set; }
    [Column("imdb_rating", TypeName = "float", Order = 16)]
    public float ImdbRating { get; set; }
    [Column("imdb_votes", TypeName = "int", Order = 17)]
    public int ImdbVotes { get; set; }
    [Column("type", TypeName = "varchar(10)", Order = 18)]
    public string Type { get; set; }
    [Column("dvd_release_date", TypeName = "datetime", Order = 19)]
    public DateTime ReleaseDateDvd { get; set; }
    [Display(Name = "DVD Release")]
    [Column("boxoffice", TypeName = "varchar(250)", Order = 20)]
    public string BoxOffice { get; set; }
    [Column("production", TypeName = "varchar(150)", Order = 21)]
    public string Production { get; set; }
    [Column("website", TypeName = "varchar(150)", Order = 22)]
    public string Website { get; set; }
    [Column("response", TypeName = "bit", Order = 23)]
    public bool Response { get; set; }

    // relation one to many
    public virtual List<DbRating> Ratings { get; set; }
  }
}
