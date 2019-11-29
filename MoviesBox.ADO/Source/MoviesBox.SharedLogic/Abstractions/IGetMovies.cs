namespace MoviesBox.SharedLogic
{
  public interface IGetMovies
  {
    IMovie GetMovies(string searchParam, int pageNumber);
    IMovieFullInfo GetMovie(string imdbId);
  }
}
