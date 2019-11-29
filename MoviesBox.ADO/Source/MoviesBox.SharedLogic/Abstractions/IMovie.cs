using System;
using System.Collections.Generic;

namespace MoviesBox.SharedLogic
{
  public interface IMovie
  {
    List<ISearch> Search { get; set; }
    string TotalResults { get; set; }
    string Response { get; set; }
    bool Success { get; set; }
  }
}
