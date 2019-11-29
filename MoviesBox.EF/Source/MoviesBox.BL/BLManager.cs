using AutoMapper;
using MoviesBox.BL.Model;
using MoviesBox.EFModel;
using MoviesBox.Services.Client;
using MoviesBox.Services.Model;

namespace MoviesBox.BL
{
  public class BLManager
  {
    /// <summary>
    /// Finds the movies.
    /// </summary>
    /// <param name="searchRequest">The search request.</param>
    public SearchMovie FindMovies(string searchRequest, int pageNumber)
    {
      var instance = new MovieBoxApiService();
      ApiMoviesResponse response = instance.GetMovies(searchRequest, pageNumber);
      SearchMovie result = MapMovieApiEntities(response);

      return result;
    }

    /// <summary>
    /// Gets the movie information.
    /// </summary>
    /// <param name="imbdId">The imbd identifier.</param>
    public MovieFullInfo GetMovieInfo(string imbdId)
    {
      // gets movie info from db
      var dbInstance = new DbManager();
      DbMovieFullInfo movieFromDb = dbInstance.GetMovieByImdbId(imbdId);
      MovieFullInfo movie = MapFullMovieDbEntitieToBl(movieFromDb);
      if (movie != null)
      {
        return movie;
      }

      // gets movie info from api 
      var service = new MovieBoxApiService();
      ApiMovieFullInfo movieFromApi = service.GetMovie(imbdId);
      if (movieFromApi != null)
      {
        DbMovieFullInfo dbMoveEntity = MapApiFullInfoMovieToDb(movieFromApi);

        // add movie to db
        dbInstance.AddMovie(dbMoveEntity);
        MovieFullInfo movieBl = MapFullMovieDbEntitieToBl(dbMoveEntity);

        return movieBl;
      }

      return new MovieFullInfo();
    }

    /// <summary>
    /// Maps the API full information movie to database.
    /// </summary>
    /// <param name="movieFromApi">The movie from API.</param>
    private DbMovieFullInfo MapApiFullInfoMovieToDb(ApiMovieFullInfo movieFromApi)
    {
      var config = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<ApiMovieFullInfo, DbMovieFullInfo>();
        cfg.CreateMap<ApiRating, DbRating>();
      });
      config.AssertConfigurationIsValid();

      IMapper iMapper = config.CreateMapper();
      DbMovieFullInfo destination = iMapper.Map<ApiMovieFullInfo, DbMovieFullInfo>(movieFromApi);

      return destination;
    }

    /// <summary>
    /// Maps the full info movie entities
    /// from db model to Bl model.
    /// </summary>
    /// <param name="movie">The movie.</param>
    private MovieFullInfo MapFullMovieDbEntitieToBl(DbMovieFullInfo movie)
    {
      var config = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<DbMovieFullInfo, MovieFullInfo>();
        cfg.CreateMap<DbRating, MovieRating>();
      });
      config.AssertConfigurationIsValid();

      IMapper iMapper = config.CreateMapper();
      MovieFullInfo destination = iMapper.Map<DbMovieFullInfo, MovieFullInfo>(movie);

      return destination;
    }

    /// <summary>
    /// Maps the full info movie entities
    /// from api model to Bl model.
    /// </summary>
    /// <param name="movie">The movie.</param>
    private SearchMovie MapMovieApiEntities(ApiMoviesResponse movieResponse)
    {
      var config = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<ApiMoviesResponse, SearchMovie>();
        cfg.CreateMap<ApiSearch, SearchDetails>();
      });
      config.AssertConfigurationIsValid();

      IMapper iMapper = config.CreateMapper();
      SearchMovie destination = iMapper.Map<ApiMoviesResponse, SearchMovie>(movieResponse);

      return destination;
    }
  }
}
