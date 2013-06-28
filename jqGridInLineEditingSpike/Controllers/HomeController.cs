using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jqGridInLineEditingSpike.Controllers
{
  using Models;
  using Services;
  using Trirand.Web.Mvc;

  public class HomeController : Controller
  {
    public BookRepository BookRepository { get; set; }

    public HomeController()
    {
      BookRepository = new BookRepository();
    }
    
    public ActionResult Index()
    {
      ViewBag.Message = "This is a test";
      var gridModel = new BooksJqGridModel();
      SetupBookGrid(gridModel.BooksGrid);
      gridModel.BooksGrid.DataUrl = Url.Action("GetBooks");
      gridModel.BooksGrid.EditUrl = Url.Action("EditBook");
      gridModel.BooksGrid.ClientSideEvents.RowSelect = "editRow";

      return View(gridModel);
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your app description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }

    private void SetupBookGrid(JQGrid grid)
    {
      var authorColumn = grid.Columns.Find(c => c.DataField == "Author");
      var titleColumn = grid.Columns.Find(c => c.DataField == "Title");
      var descriptionColumn = grid.Columns.Find(c => c.DataField == "Description");

      authorColumn.EditClientSideValidators.Add(new RequiredValidator());
      titleColumn.EditClientSideValidators.Add(new RequiredValidator());
      descriptionColumn.EditClientSideValidators.Add(new RequiredValidator());
    }

    public ActionResult GetBooks()
    {
      var gridModel = new BooksJqGridModel();
      SetupBookGrid(gridModel.BooksGrid);

      var books = BookRepository.AllBooks();
      return gridModel.BooksGrid.DataBind(books);
    }

    public ActionResult EditBook(BookModel book)
    {
      BookModel persistedBook;
      if (book.Id == 0)
      {
        persistedBook = BookRepository.Add(book);
      }
      else
      {
        persistedBook = BookRepository.Update(book);
      }
      return new JsonResult
        {
          JsonRequestBehavior = JsonRequestBehavior.AllowGet,
          Data = new {id = persistedBook.Id, error = string.Empty}
        };
    }
  }
}
