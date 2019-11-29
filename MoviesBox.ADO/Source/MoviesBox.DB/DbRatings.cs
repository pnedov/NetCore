using MoviesBox.SharedLogic;
namespace MoviesBox.DB
{
  public class DbRating : IRating
  {
    public string Source { get; set; }
    public string Value { get; set; }
  }
}
