using System.Web.Mvc;
using GotNext.Web.Infrastructure.Security;

namespace GotNext.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new RequireSecureConnectionFilter()); //Leave first in list
            filters.Add(new HandleErrorAttribute());
        }
    }
}
