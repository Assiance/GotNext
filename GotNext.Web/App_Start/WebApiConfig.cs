using System.Web.Http;
using System.Web.Http.Cors;
using GotNext.Web.Infrastructure.Security;
using Microsoft.Owin.Security.OAuth;

namespace GotNext.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            //enable cors globally
            var corsAttr = new EnableCorsAttribute("http://localhost:52613", "*", "*"); //todo: get path from config
            config.EnableCors(corsAttr);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MessageHandlers.Add(new EnforceHttpsHandler());
        }
    }
}
