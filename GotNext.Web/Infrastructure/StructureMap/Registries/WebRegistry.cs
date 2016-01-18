using System.Web;
using Microsoft.Owin;
using StructureMap;
using StructureMap.Graph;

namespace GotNext.Web.Infrastructure.StructureMap.Registries
{
    public class WebRegistry : Registry
    {
        public WebRegistry()
        {
            this.Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });

            For<IOwinContext>().Use(() => HttpContext.Current.GetOwinContext());
        }
    }
}