using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jqGridInLineEditingSpike.Services
{
  using Models;

  public class BookRepository
  {
    private static readonly IDictionary<long, BookModel> Books = new Dictionary<long, BookModel>();
 
    public BookModel Add(BookModel instance)
    {
      if (instance.Id == 0)
      {
        instance.Id =  Books.Any() ? Books.Keys.Max() + 1 : 1;
      }
      Books[instance.Id] = instance;
      return instance;
    }

    public BookModel Update(BookModel instance)
    {
      Books[instance.Id] = instance;
      return instance;
    }

    public IQueryable<BookModel> AllBooks()
    {
      return Books.Values.AsQueryable();
    }
  }
}