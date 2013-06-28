namespace jqGridInLineEditingSpike.Models
{
  using System.Collections.Generic;
  using Trirand.Web.Mvc;

  public class BooksJqGridModel
  {
    public JQGrid BooksGrid { get; set; }

    public BooksJqGridModel()
    {
      BooksGrid = new JQGrid
        {
          Columns = new List<JQGridColumn>
            {
              new JQGridColumn {DataField = "Id", PrimaryKey = true, Visible = false, Searchable = false},
              new JQGridColumn {DataField = "Title", Editable = true},
              new JQGridColumn {DataField = "Author", Editable = true},
              new JQGridColumn {DataField = "Description", Editable = true},
            },
          ToolBarSettings = {ShowRefreshButton = true, ShowAddButton = true}
        };
    }
  }
}