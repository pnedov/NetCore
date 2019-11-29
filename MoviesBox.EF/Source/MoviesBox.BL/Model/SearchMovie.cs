using System.Collections.Generic;

namespace MoviesBox.BL.Model
{
  public class SearchMovie
  {
    public List<SearchDetails> Search { get; set; }
    public string TotalResults { get; set; }
    public string Response { get; set; }
    public bool Success { get; set; }
  }
}
