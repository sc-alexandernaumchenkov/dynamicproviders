using System.Web;
using System.Web.Mvc;

namespace DynamicProviders.NetFrameworkApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
