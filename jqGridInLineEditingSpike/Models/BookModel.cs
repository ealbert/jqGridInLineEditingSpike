using System;
using System.Linq;
using System.Web;

namespace jqGridInLineEditingSpike.Models
{
  using System.ComponentModel.DataAnnotations;

  public class BookModel
  {
    public long Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
  }
}