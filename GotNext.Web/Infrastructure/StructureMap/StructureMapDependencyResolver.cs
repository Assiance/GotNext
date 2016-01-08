using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StructureMap;

namespace GotNext.Web.Infrastructure.StructureMap
{
    public class StructureMapDependencyResolver : IDependencyResolver
    {
        private readonly Func<IContainer> _containerFactory;

        public StructureMapDependencyResolver(Func<IContainer> containerFactory)
        {
            this._containerFactory = containerFactory;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null)
            {
                return null;
            }

            var container = this._containerFactory();

            return serviceType.IsAbstract || serviceType.IsInterface
                       ? container.TryGetInstance(serviceType)
                       : container.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this._containerFactory().GetAllInstances(serviceType).Cast<object>();
        }
    }
}