using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesBox.BL
{
  /// <summary>
  /// Manage pagination functionality for result
  /// search page.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class PaginatedList<T> : List<T>
  {
    public int PageIndex { get; private set; }
    public int TotalPages { get; private set; }

    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
    {
      PageIndex = pageIndex;
      TotalPages = (int)Math.Ceiling(count / (double)pageSize);

      this.AddRange(items);
    }

    public bool HasPreviousPage
    {
      get
      {
        return (PageIndex > 1);
      }
    }

    public bool HasNextPage
    {
      get
      {
        return (PageIndex < TotalPages);
      }
    }

    /// <summary>
    /// Creates the specified source.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="pageIndex">Index of the page.</param>
    /// <param name="pageSize">Size of the page.</param>
    /// <param name="totalItemsCount">The total items count.</param>
    public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize, int totalItemsCount)
    {
      return new PaginatedList<T>(source.ToList(), totalItemsCount, pageIndex, pageSize);
    }
  }
}