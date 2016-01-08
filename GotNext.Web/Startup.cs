using GotNext.Domain.Services;
using GotNext.Domain.Services.Interfaces;
using GotNext.Web;

using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace GotNext.Web
{
    public class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            var oAuthService = new ApplicationOAuthService();
            oAuthService.ConfigureAuth(app, PublicClientId, OAuthOptions);
        }
    }
}
