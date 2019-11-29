using MoviesBox.SharedLogic;
using MoviesBox.SharedLogic.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace MoviesBox.DB
{
  public class DbManager
  {
    private readonly string connectionString;

    public DbManager()
    {
      connectionString = HelperMethods.GetAppConfigValue("ConnectionStrings");
    }

    /// <summary>
    /// Gets the movie by imdb identifier.
    /// </summary>
    /// <param name="imdbId">The imdb identifier.</param>
    public IMovieFullInfo GetMovieByImdbId(string imdbId)
    {
      var movie = new DbMovie();
      using (var connection = new SqlConnection(connectionString))
      {
        connection.Open();
        string sql = $"SELECT * FROM Movies WHERE imdb_id = '{imdbId}'";
        var command = new SqlCommand(sql, connection);
        using (SqlDataReader dataReader = command.ExecuteReader())
        {
          if (!dataReader.HasRows)
          {
            return null;
          }

          while (dataReader.Read())
          {
            movie.ImdbID = Convert.ToString(dataReader["imdb_id"]);
            movie.moveiID = Convert.ToInt32(dataReader["movie_id"]);
            movie.Title = Convert.ToString(dataReader["title"]);
            movie.Year = Convert.ToString(dataReader["year"]);
            movie.Rated = Convert.ToString(dataReader["rated"]);
            movie.Released = Convert.ToDateTime(dataReader["released"]);
            movie.Runtime = Convert.ToString(dataReader["runtime"]);
            movie.Genre = Convert.ToString(dataReader["genre"]);
            movie.Director = Convert.ToString(dataReader["director"]);
            movie.Writer = Convert.ToString(dataReader["writer"]);
            movie.Actors = Convert.ToString(dataReader["actors"]);
            movie.Plot = Convert.ToString(dataReader["plot"]);
            movie.Language = Convert.ToString(dataReader["language"]);
            movie.Country = Convert.ToString(dataReader["country"]);
            movie.Awards = Convert.ToString(dataReader["awards"]);
            movie.Poster = Convert.ToString(dataReader["poster"]);
            movie.Metascore = Convert.ToInt32(dataReader["metascore"]);
            movie.ImdbRating = Convert.ToDouble(dataReader["imdb_rating"]);
            movie.ImdbVotes = Convert.ToInt32(dataReader["imdb_votes"]);
            movie.Type = Convert.ToString(dataReader["type"]);
            movie.ReleaseDateDvd = Convert.ToDateTime(dataReader["dvd_release_date"]);
            movie.BoxOffice = Convert.ToString(dataReader["boxoffice"]);
            movie.Production = Convert.ToString(dataReader["production"]);
            movie.Website = Convert.ToString(dataReader["website"]);
            movie.Response = Convert.ToBoolean(dataReader["response"]);
          }
        }

        // read from dbo.Ratings relative data
        var ratings = new List<IRating>();
        sql = $"SELECT * FROM Ratings WHERE movie_id = '{movie.moveiID}'";
        command = new SqlCommand(sql, connection);
        using (SqlDataReader dataReader = command.ExecuteReader())
        {
          if (dataReader.HasRows)
          {
            while (dataReader.Read())
            {
              var rating = new DbRating();
              rating.Source = Convert.ToString(dataReader["source"]);
              rating.Value = Convert.ToString(dataReader["value"]);
              ratings.Add((IRating)rating);
            }
            movie.Ratings = ratings;
          }
        }
      }

      return movie;
    }

    /// <summary>
    /// Adds the movie.
    /// </summary>
    /// <param name="movieFromApi">The movie from API.</param>
    public void AddMovie(IMovieFullInfo movieFromApi)
    {
      using (var connection = new SqlConnection(connectionString))
      {
        connection.Open();
        string sql = $@"
          INSERT INTO Movies (
             imdb_id, title ,year
             ,rated ,released ,runtime
             ,genre ,director ,writer
             ,actors ,plot ,language
             ,country ,awards ,poster
             ,metascore ,imdb_rating ,imdb_votes
             ,type ,dvd_release_date ,boxoffice
             ,production,website ,response ) 
          VALUES (
              @ImdbID
             ,@Title
             ,'{movieFromApi.Year}'
             ,'{movieFromApi.Rated}'
             ,@Released
             ,'{movieFromApi.Runtime}'
             ,'{movieFromApi.Genre}'
             ,@Director
             ,@Writer
             ,@Actors
             ,@Plot
             ,'{movieFromApi.Language}'
             ,@Country
             ,'{movieFromApi.Awards}'
             ,'{movieFromApi.Poster}'
             ,{movieFromApi.Metascore}
             ,{movieFromApi.ImdbRating}
             ,{movieFromApi.ImdbVotes}
             ,'{movieFromApi.Type}'
             ,@ReleaseDateDvd
             ,'{movieFromApi.BoxOffice}'
             ,'{movieFromApi.Production}'
             ,'{movieFromApi.Website}'
             ,@Response);

          SELECT SCOPE_IDENTITY();";
        var command = new SqlCommand(sql, connection);
        command.Parameters.Add("@ImdbID", SqlDbType.VarChar, 50).Value = movieFromApi.ImdbID;
        command.Parameters.Add("@Director", SqlDbType.VarChar, 150).Value = movieFromApi.Director;
        command.Parameters.Add("@Writer", SqlDbType.VarChar, 350).Value = movieFromApi.Writer;
        command.Parameters.Add("@Title", SqlDbType.VarChar, 150).Value = movieFromApi.Title;
        command.Parameters.Add("@Actors", SqlDbType.VarChar, 350).Value = movieFromApi.Actors;
        command.Parameters.Add("@Plot", SqlDbType.VarChar, 250).Value = movieFromApi.Plot;
        command.Parameters.Add("@Country", SqlDbType.VarChar, 100).Value = movieFromApi.Country;
        command.Parameters.AddWithValue("@Released", movieFromApi.Released);
        command.Parameters.AddWithValue("@ReleaseDateDvd", movieFromApi.ReleaseDateDvd);
        command.Parameters.AddWithValue("@Response", movieFromApi.Response);
        object objId = command.ExecuteScalar();

        // add records to related Ratings table
        if (objId != null)
        {
          int movieId = Convert.ToInt32(objId);
          foreach (IRating rating in movieFromApi.Ratings)
          {
            sql = $@"
              INSERT INTO Ratings (
                 source
                 ,value
                 ,movie_id)
              VALUES (
                  '{rating.Source}'
                 ,'{rating.Value}'
                 ,{movieId}
              )";

            var commandRating = new SqlCommand(sql, connection);
            commandRating.ExecuteNonQuery();
          }
        }
      }
    }
  }
}