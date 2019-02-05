using System.Web;
using System.Web.Mvc;

namespace FSP.Engenharia.UI.Site
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
