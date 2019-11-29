using MoviesBox.DB;
using MoviesBox.Services.Client;
using MoviesBox.SharedLogic;

namespace MoviesBox.BL
{
  public class MoviesManager
  {
    /// <summary>
    /// Finds the movies.
    /// </summary>
    /// <param name="searchRequest">The search request.</param>
    /// <param name="pageNumber">The page number.</param>
    public IMovie FindMovies(string searchRequest, int pageNumber)
    {
      var instance = new MovieBoxApiService();
      var result = instance.GetMovies(searchRequest, pageNumber);

      return result;
    }

    /// <summary>
    /// Gets the movie information.
    /// </summary>
    /// <param name="imbdId">The imbd identifier.</param>
    public IMovieFullInfo GetMovieInfo(string imbdId)
    {
      var dbInstance = new DbManager();
      IMovieFullInfo movieFromDb = dbInstance.GetMovieByImdbId(imbdId);

      // gets movie info from db
      if (movieFromDb != null)
      {
        return movieFromDb;
      }

      // gets movie info from api 
      var service = new MovieBoxApiService();
      IMovieFullInfo movieFromApi = service.GetMovie(imbdId);
      if (movieFromApi != null)
      {
        dbInstance.AddMovie(movieFromApi);
      }

      return movieFromApi;
    }
  }
}
