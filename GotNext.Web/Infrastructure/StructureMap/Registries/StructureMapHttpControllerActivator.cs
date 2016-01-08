using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using StructureMap;

namespace GotNext.Web.Infrastructure.StructureMap.Registries
{
    public class StructureMapHttpControllerActivator : IHttpControllerActivator
    {
        private readonly IContainer _container;

        public StructureMapHttpControllerActivator(IContainer container)
        {
            this._container = container;
        }

        public IHttpController Create(
                HttpRequestMessage request,
                HttpControllerDescriptor controllerDescriptor,
                Type controllerType)
        {
            return (IHttpController)_container.GetInstance(controllerType);
        }
    }
}