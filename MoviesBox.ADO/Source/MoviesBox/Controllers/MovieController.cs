﻿using MoviesBox.SharedLogic.Helpers;
using Microsoft.AspNetCore.Mvc;
using MoviesBox.BL;
using MoviesBox.SharedLogic;

namespace MoviesBox.Controllers
{
  /// <summary>
  ///  Actions with movies full info.
  /// </summary>
  public class MovieController : Controller
  {
    [HttpGet]
    [Route("movie/{imdbIdParam}", Name = "MovieDetails")]
    public IActionResult Index(string imdbIdParam)
    {
      if (string.IsNullOrEmpty(imdbIdParam))
      {
        return View(null);
      }

      var moviesInstance = new MoviesManager();
      IMovieFullInfo movie = moviesInstance.GetMovieInfo(imdbIdParam);

      string imdbUrl = HelperMethods.GetAppConfigValue("imdbUrl");
      ViewBag.ImDbUrl = imdbUrl += movie.ImdbID;

      return View(movie);
    }
  }
}