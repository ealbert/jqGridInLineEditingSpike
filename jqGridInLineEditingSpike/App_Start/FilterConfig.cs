using System.Web;
using System.Web.Mvc;

namespace jqGridInLineEditingSpike
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
    }
  }
}