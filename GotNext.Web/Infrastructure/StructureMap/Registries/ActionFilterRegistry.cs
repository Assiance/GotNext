using System;
using System.Web.Mvc;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.TypeRules;

namespace GotNext.Web.Infrastructure.StructureMap.Registries
{
    public class ActionFilterRegistry : Registry
    {
        public ActionFilterRegistry(Func<IContainer> containerFactory)
        {
            var solutionName = typeof(WebApiApplication).Namespace;

            this.For<IFilterProvider>().Use(new StructureMapFilterProvider(containerFactory));

            this.Policies.SetAllProperties(x =>
                x.Matching(p =>
                p.DeclaringType.CanBeCastTo(typeof(ActionFilterAttribute)) &&
                p.DeclaringType.Namespace.StartsWith(solutionName) &&
                !p.PropertyType.IsPrimitive &&
                p.PropertyType != typeof(string)));
        }
    }
}