﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MoviesBox.BL;
using MoviesBox.SharedLogic;

namespace MoviesBox.Controllers
{
  public class HomeController : Controller
  {
    // constant for this API
    const int pageSize = 10;

    [HttpGet]
    public IActionResult Index(
    string currentFilter,
    string searchParam,
    int? pageNumber)
    {
      if (searchParam != null)
      {
        pageNumber = 1;
      }
      else
      {
        searchParam = currentFilter;
      }

      ViewData["CurrentFilter"] = searchParam;

      // validation
      if (string.IsNullOrEmpty(searchParam) || string.IsNullOrWhiteSpace(searchParam))
      {
        return View(null);
      }

      var moviesInstance = new MoviesManager();
      IMovie movies = moviesInstance.FindMovies(searchParam, pageNumber ?? 1);
      ViewData["TotalResults"] = movies.TotalResults;

      return View(PaginatedList<ISearch>.Create(movies.Search.AsQueryable(), pageNumber ?? 1, pageSize, int.Parse(movies.TotalResults)));
    }
  }
}
