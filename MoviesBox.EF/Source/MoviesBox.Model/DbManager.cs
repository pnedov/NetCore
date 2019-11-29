using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MoviesBox.EFModel
{
  /// <summary>
  /// Manages the db movie info
  /// </summary>
  public class DbManager
  {
    /// <summary>
    /// Gets the movie by imdb identifier.
    /// </summary>
    /// <param name="imdbId">The imdb identifier.</param>
    public DbMovieFullInfo GetMovieByImdbId(string imdbId)
    {
      using (var context = new DbMovieContext())
      {
        DbMovieFullInfo movie = context.Movies
              .Include(b => b.Ratings)
              .Where(n => n.ImdbID == imdbId)
              .FirstOrDefault();

        return movie;
      }
    }

    /// <summary>
    /// Adds the movie.
    /// </summary>
    public void AddMovie(DbMovieFullInfo dbMovie)
    {
      using (var context = new DbMovieContext())
      {
        context.Movies.Add(dbMovie);
        context.SaveChanges();
        return;
      }
    }

  }
}
