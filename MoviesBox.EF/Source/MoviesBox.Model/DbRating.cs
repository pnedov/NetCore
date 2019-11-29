using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesBox.EFModel
{
  [Table("Ratings")]
  public class DbRating
  {
    [AutoMapper.IgnoreMap()]
    [Key]
    [Column("rate_id", TypeName = "int", Order = 0)]
    public int rateID { get; set; }
    [Column("source", TypeName = "varchar(150)", Order = 1)]
    public string Source { get; set; }
    [Column("value", TypeName = "varchar(25)", Order = 2)]
    public string Value { get; set; }

    [ForeignKey("movie_id")]
    [AutoMapper.IgnoreMap()]
    public virtual DbMovieFullInfo Movie { get; set; }
  }
}
