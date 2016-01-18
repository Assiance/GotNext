using System.Security.Principal;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using StructureMap;

namespace GotNext.Web.Infrastructure.StructureMap.Registries
{
    public class MvcRegistry : Registry
    {
        public MvcRegistry()
        {
            this.For<BundleCollection>().Use(BundleTable.Bundles);
            this.For<RouteCollection>().Use(RouteTable.Routes);
            this.For<IIdentity>().Use(() => HttpContext.Current.User.Identity);
            this.For<HttpSessionStateBase>().Use(() => new HttpSessionStateWrapper(HttpContext.Current.Session));
            this.For<HttpContextBase>().Use(() => new HttpContextWrapper(HttpContext.Current));
            this.For<HttpServerUtilityBase>().Use(() => new HttpServerUtilityWrapper(HttpContext.Current.Server));
        }
    }
}