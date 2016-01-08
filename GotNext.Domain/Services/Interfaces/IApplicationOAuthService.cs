using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace GotNext.Domain.Services.Interfaces
{
    public interface IApplicationOAuthService
    {
        Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context);
        Task TokenEndpoint(OAuthTokenEndpointContext context);
        Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context);
        Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context, string publicClientId);
        void ConfigureAuth(IAppBuilder app, string publicClientId, OAuthAuthorizationServerOptions oAuthOptions);
    }
}