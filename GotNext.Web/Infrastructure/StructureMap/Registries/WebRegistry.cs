using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using StructureMap.Configuration.DSL;
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