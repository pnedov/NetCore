using System.Collections.Generic;
using RestSharp;
using MoviesBox.Services.Model;
using MoviesBox.SharedLogic.Helpers;
using Newtonsoft.Json;

namespace MoviesBox.Services.Client
{
  public class MovieBoxApiService 
  {
    /// <summary>
    /// Gets or sets the API client.
    /// </summary>
    /// <value>An instance of the ApiClient</value>
    public ApiClient apiClient { get; set; }

    /// <summary>
    /// Gets or sets the API key.
    /// </summary>
    private string apiKey { get; set; }

    /// <summary>
    /// Gets or sets the URL API.
    /// </summary>
    private string apiUrl { get; set; }

    /// <summary>
    /// Gets or sets the type of content.
    /// </summary>
    private string apiTypeContent { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MovieBoxApiService"/> class.
    /// </summary>
    /// <param name="basePath">The base path.</param>
    public MovieBoxApiService()
    {
        apiKey = HelperMethods.GetAppConfigValue("apiKey");
        apiUrl = HelperMethods.GetAppConfigValue("apiUrl");
        apiTypeContent = HelperMethods.GetAppConfigValue("apiTypeContent");
        apiClient = new ApiClient(apiUrl);
    }

    /// <summary>
    /// Gets the movies from om database.
    /// </summary>
    /// <param name="searchRequest">The search.</param>
    /// <param name="pageNumber">The page number.</param>
    public ApiMoviesResponse GetMovies(string searchRequest, int pageNumber)
    {
      // validate
      if (string.IsNullOrEmpty(searchRequest))
      {
        throw new ApiException(400, $"Missing required parameter {nameof(searchRequest)}");
      }

      if (string.IsNullOrEmpty(apiKey))
      {
        throw new ApiException(400, $"Missing required parameter {nameof(apiKey)}");
      }

      if (string.IsNullOrEmpty(apiTypeContent))
      {
        throw new ApiException(400, $"Missing required parameter {nameof(apiTypeContent)}");
      }

      var path = "";
      var queryParams = new Dictionary<string, string>();
      var headerParams = new Dictionary<string, string>();
      var formParams = new Dictionary<string, string>();

      queryParams.Add("s", searchRequest);
      queryParams.Add("r", "json");
      queryParams.Add("type", apiTypeContent);
      queryParams.Add("apikey", apiKey);
      queryParams.Add("page", pageNumber.ToString());

      // make the HTTP request
      IRestResponse response = (IRestResponse)apiClient.CallApi(path, Method.GET, queryParams, headerParams, formParams, null);

      if (((int)response.StatusCode) > 400)
      {
        throw new ApiException((int)response.StatusCode, "Error calling OMDB API: " + response.Content, response.Content);
      }
      else if (response.StatusCode == 0)
      {
        throw new ApiException((int)response.StatusCode, "Error calling OMDB API: " + response.ErrorMessage, response.ErrorMessage);
      }

      // deserialize
      ApiMoviesResponse result = JsonConvert.DeserializeObject<ApiMoviesResponse>(response.Content, new JsonSerializerSettings
      {
        TypeNameHandling = TypeNameHandling.Auto
      });

      return result;
    }

    /// <summary>
    /// Gets the movie full information.
    /// </summary>
    /// <param name="imdbId">The imdb identifier.</param>
    public ApiMovieFullInfo GetMovie(string imdbId)
    {
      // validate
      if (string.IsNullOrEmpty(imdbId))
      {
        throw new ApiException(400, $"Missing required parameter {nameof(imdbId)}");
      }

      if (string.IsNullOrEmpty(apiKey))
      {
        throw new ApiException(400, $"Missing required parameter {nameof(apiKey)}");
      }

      var path = "";
      var queryParams = new Dictionary<string, string>();
      var headerParams = new Dictionary<string, string>();
      var formParams = new Dictionary<string, string>();

      queryParams.Add("i", imdbId);
      queryParams.Add("r", "json");
      queryParams.Add("apikey", apiKey);

      // make the HTTP request
      IRestResponse response = (IRestResponse)apiClient.CallApi(path, Method.GET, queryParams, headerParams, formParams, null);

      if (((int)response.StatusCode) > 400)
      {
        throw new ApiException((int)response.StatusCode, "Error calling OMDB API: " + response.Content, response.Content);
      }
      else if (response.StatusCode == 0)
      {
        throw new ApiException((int)response.StatusCode, "Error calling OMDB API: " + response.ErrorMessage, response.ErrorMessage);
      }

      // deserialize
      ApiMovieFullInfo result = JsonConvert.DeserializeObject<ApiMovieFullInfo>(response.Content, new JsonSerializerSettings
      {
        TypeNameHandling = TypeNameHandling.Auto
      });

      return result;
    }
  }
}
