using System.Web;
using System.Web.Mvc;
using Website_first_build.Filter;

namespace Website_first_build
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
