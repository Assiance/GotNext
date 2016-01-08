using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GotNext.Domain.Services.Interfaces;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace GotNext.Domain.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;
        private readonly IApplicationOAuthService _applicationOAuthService;

        public ApplicationOAuthProvider(string publicClientId, IApplicationOAuthService applicationOAuthService)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            this._publicClientId = publicClientId;

            _applicationOAuthService = applicationOAuthService;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            await _applicationOAuthService.GrantResourceOwnerCredentials(context);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            return _applicationOAuthService.TokenEndpoint(context);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            return _applicationOAuthService.ValidateClientAuthentication(context);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            return _applicationOAuthService.ValidateClientRedirectUri(context, _publicClientId);
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
}