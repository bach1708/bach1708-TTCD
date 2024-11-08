using System.Web;
using System.Web.Mvc;

namespace K22CNT2_NongVanBach_2210900003
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
