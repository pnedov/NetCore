namespace MoviesBox.SharedLogic
{
  public interface ISearch
  {
    string Title { get; set; }
    string Year { get; set; }
    string ImdbID { get; set; }
    string Type { get; set; }
    string Poster { get; set; }
  }
}
