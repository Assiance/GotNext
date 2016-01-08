using System;
using System.Collections.Generic;
using System.Web.Mvc;
using StructureMap;

namespace GotNext.Web.Infrastructure.StructureMap
{
    public class StructureMapFilterProvider : FilterAttributeFilterProvider
    {
        private readonly Func<IContainer> _container;

        public StructureMapFilterProvider(Func<IContainer> container)
        {
            this._container = container;
        }

        public override IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(controllerContext, actionDescriptor);

            var container = this._container();

            foreach (var filter in filters)
            {
                container.BuildUp(filter.Instance);
                yield return filter;
            }
        }
    }
}