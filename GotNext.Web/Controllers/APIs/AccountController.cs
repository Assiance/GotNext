﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using GotNext.Domain.Managers;
using GotNext.Domain.Services;
using GotNext.Model.Models.Domain.Account;
using GotNext.Model.Models.Domain.Authentication;
using GotNext.Web.Infrastructure.ActionResults;
using GotNext.Web.Infrastructure.Extensions;
using GotNext.Web.Infrastructure.Providers;
using GotNext.Web.ViewModels.Account;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;

namespace GotNext.Web.Controllers.APIs
{
    [Authorize]
    [RoutePrefix("api/Account")]
    [EnableCors("http://localhost:52613", "*", "*")]
    public class AccountController : ApiController
    {
        private readonly MemberManager _memberManager;

        //private const string LocalLoginProvider = "Local";

        public AccountController(MemberManager memberManager)
        {
            _memberManager = memberManager;
        }

        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return this._userManager ?? this.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }

        //    private set
        //    {
        //        this._userManager = value;
        //    }
        //}

        //public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        //// GET api/Account/UserInfo
        //[HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        //[Route("UserInfo")]
        //public UserInfoViewModel GetUserInfo()
        //{
        //    ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(this.User.Identity as ClaimsIdentity);

        //    return new UserInfoViewModel
        //    {
        //        Email = this.User.Identity.GetUserName(),
        //        HasRegistered = externalLogin == null,
        //        LoginProvider = externalLogin != null ? externalLogin.LoginProvider : null
        //    };
        //}

        //// POST api/Account/Logout
        //[Route("Logout")]
        //public IHttpActionResult Logout()
        //{
        //    this.Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
        //    return this.Ok();
        //}

        //// GET api/Account/ManageInfo?returnUrl=%2F&generateState=true
        //[Route("ManageInfo")]
        //public async Task<ManageInfoViewModel> GetManageInfo(string returnUrl, bool generateState = false)
        //{
        //    IdentityUser user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());

        //    if (user == null)
        //    {
        //        return null;
        //    }

        //    List<UserLoginInfoViewModel> logins = new List<UserLoginInfoViewModel>();

        //    foreach (IdentityUserLogin linkedAccount in user.Logins)
        //    {
        //        logins.Add(new UserLoginInfoViewModel
        //        {
        //            LoginProvider = linkedAccount.LoginProvider,
        //            ProviderKey = linkedAccount.ProviderKey
        //        });
        //    }

        //    if (user.PasswordHash != null)
        //    {
        //        logins.Add(new UserLoginInfoViewModel
        //        {
        //            LoginProvider = LocalLoginProvider,
        //            ProviderKey = user.UserName,
        //        });
        //    }

        //    return new ManageInfoViewModel
        //    {
        //        LocalLoginProvider = LocalLoginProvider,
        //        Email = user.UserName,
        //        Logins = logins,
        //        ExternalLoginProviders = this.GetExternalLogins(returnUrl, generateState)
        //    };
        //}

        //// POST api/Account/ChangePassword
        //[Route("ChangePassword")]
        //public async Task<IHttpActionResult> ChangePassword(ChangePasswordModel model)
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return this.BadRequest(this.ModelState);
        //    }

        //    IdentityResult result = await this.UserManager.ChangePasswordAsync(this.User.Identity.GetUserId(), model.OldPassword, model.NewPassword);

        //    if (!result.Succeeded)
        //    {
        //        return this.GetErrorResult(result);
        //    }

        //    return this.Ok();
        //}

        //// POST api/Account/SetPassword
        //[Route("SetPassword")]
        //public async Task<IHttpActionResult> SetPassword(SetPasswordModel model)
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return this.BadRequest(this.ModelState);
        //    }

        //    IdentityResult result = await this.UserManager.AddPasswordAsync(this.User.Identity.GetUserId(), model.NewPassword);

        //    if (!result.Succeeded)
        //    {
        //        return this.GetErrorResult(result);
        //    }

        //    return this.Ok();
        //}

        //// POST api/Account/AddExternalLogin
        //[Route("AddExternalLogin")]
        //public async Task<IHttpActionResult> AddExternalLogin(AddExternalLoginModel model)
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return this.BadRequest(this.ModelState);
        //    }

        //    this.Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

        //    AuthenticationTicket ticket = this.AccessTokenFormat.Unprotect(model.ExternalAccessToken);

        //    if (ticket == null || ticket.Identity == null || (ticket.Properties != null
        //        && ticket.Properties.ExpiresUtc.HasValue
        //        && ticket.Properties.ExpiresUtc.Value < DateTimeOffset.UtcNow))
        //    {
        //        return this.BadRequest("External login failure.");
        //    }

        //    ExternalLoginData externalData = ExternalLoginData.FromIdentity(ticket.Identity);

        //    if (externalData == null)
        //    {
        //        return this.BadRequest("The external login is already associated with an account.");
        //    }

        //    IdentityResult result = await this.UserManager.AddLoginAsync(this.User.Identity.GetUserId(),
        //        new UserLoginInfo(externalData.LoginProvider, externalData.ProviderKey));

        //    if (!result.Succeeded)
        //    {
        //        return this.GetErrorResult(result);
        //    }

        //    return this.Ok();
        //}

        //// POST api/Account/RemoveLogin
        //[Route("RemoveLogin")]
        //public async Task<IHttpActionResult> RemoveLogin(RemoveLoginModel model)
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return this.BadRequest(this.ModelState);
        //    }

        //    IdentityResult result;

        //    if (model.LoginProvider == LocalLoginProvider)
        //    {
        //        result = await this.UserManager.RemovePasswordAsync(this.User.Identity.GetUserId());
        //    }
        //    else
        //    {
        //        result = await this.UserManager.RemoveLoginAsync(this.User.Identity.GetUserId(),
        //            new UserLoginInfo(model.LoginProvider, model.ProviderKey));
        //    }

        //    if (!result.Succeeded)
        //    {
        //        return this.GetErrorResult(result);
        //    }

        //    return this.Ok();
        //}

        //// GET api/Account/ExternalLogin
        //[OverrideAuthentication]
        //[HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
        //[AllowAnonymous]
        //[Route("ExternalLogin", Name = "ExternalLogin")]
        //public async Task<IHttpActionResult> GetExternalLogin(string provider, string error = null)
        //{
        //    if (error != null)
        //    {
        //        return this.Redirect(this.Url.Content("~/") + "#error=" + Uri.EscapeDataString(error));
        //    }

        //    if (!this.User.Identity.IsAuthenticated)
        //    {
        //        return new ChallengeResult(provider, this);
        //    }

        //    ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(this.User.Identity as ClaimsIdentity);

        //    if (externalLogin == null)
        //    {
        //        return this.InternalServerError();
        //    }

        //    if (externalLogin.LoginProvider != provider)
        //    {
        //        this.Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
        //        return new ChallengeResult(provider, this);
        //    }

        //    ApplicationUserEntity user = await this.UserManager.FindAsync(new UserLoginInfo(externalLogin.LoginProvider,
        //        externalLogin.ProviderKey));

        //    bool hasRegistered = user != null;

        //    if (hasRegistered)
        //    {
        //        this.Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

        //        ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(this.UserManager,
        //           OAuthDefaults.AuthenticationType);
        //        ClaimsIdentity cookieIdentity = await user.GenerateUserIdentityAsync(this.UserManager,
        //            CookieAuthenticationDefaults.AuthenticationType);

        //        AuthenticationProperties properties = ApplicationOAuthProvider.CreateProperties(user.UserName);
        //        this.Authentication.SignIn(properties, oAuthIdentity, cookieIdentity);
        //    }
        //    else
        //    {
        //        IEnumerable<Claim> claims = externalLogin.GetClaims();
        //        ClaimsIdentity identity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
        //        this.Authentication.SignIn(identity);
        //    }

        //    return this.Ok();
        //}

        //// GET api/Account/ExternalLogins?returnUrl=%2F&generateState=true
        //[AllowAnonymous]
        //[Route("ExternalLogins")]
        //public IEnumerable<ExternalLoginViewModel> GetExternalLogins(string returnUrl, bool generateState = false)
        //{
        //    IEnumerable<AuthenticationDescription> descriptions = this.Authentication.GetExternalAuthenticationTypes();
        //    List<ExternalLoginViewModel> logins = new List<ExternalLoginViewModel>();

        //    string state;

        //    if (generateState)
        //    {
        //        const int StrengthInBits = 256;
        //        state = RandomOAuthStateGenerator.Generate(StrengthInBits);
        //    }
        //    else
        //    {
        //        state = null;
        //    }

        //    foreach (AuthenticationDescription description in descriptions)
        //    {
        //        ExternalLoginViewModel login = new ExternalLoginViewModel
        //        {
        //            Name = description.Caption,
        //            Url = this.Url.Route("ExternalLogin", new
        //            {
        //                provider = description.AuthenticationType,
        //                response_type = "token",
        //                client_id = Startup.PublicClientId,
        //                redirect_uri = new Uri(this.Request.RequestUri, returnUrl).AbsoluteUri,
        //                state = state
        //            }),
        //            State = state
        //        };
        //        logins.Add(login);
        //    }

        //    return logins;
        //}

        // POST api/Account/Register
        [AllowAnonymous]
        public async Task<IHttpActionResult> Register(RegisterAccountRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _memberManager.RegisterAndSignInAsync(Mapper.Map<Registration>(request));

            if (result.HasErrors)
            {
                ModelState.AddErrors(result);
                return BadRequest(ModelState);
            }

            return Ok();
        }

        //// POST api/Account/RegisterExternal
        //[OverrideAuthentication]
        //[HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        //[Route("RegisterExternal")]
        //public async Task<IHttpActionResult> RegisterExternal(RegisterExternalModel model)
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return this.BadRequest(this.ModelState);
        //    }

        //    var info = await this.Authentication.GetExternalLoginInfoAsync();
        //    if (info == null)
        //    {
        //        return this.InternalServerError();
        //    }

        //    var user = new ApplicationUserEntity() { UserName = model.Email, Email = model.Email };

        //    IdentityResult result = await this.UserManager.CreateAsync(user);
        //    if (!result.Succeeded)
        //    {
        //        return this.GetErrorResult(result);
        //    }

        //    result = await this.UserManager.AddLoginAsync(user.Id, info.Login);
        //    if (!result.Succeeded)
        //    {
        //        return this.GetErrorResult(result);
        //    }

        //    return this.Ok();
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        this.UserManager.Dispose();
        //    }

        //    base.Dispose(disposing);
        //}

        //#region Helpers

        //private IAuthenticationManager Authentication
        //{
        //    get { return this.Request.GetOwinContext().Authentication; }
        //}

        //private IHttpActionResult GetErrorResult(IdentityResult result)
        //{
        //    if (result == null)
        //    {
        //        return this.InternalServerError();
        //    }

        //    if (!result.Succeeded)
        //    {
        //        if (result.Errors != null)
        //        {
        //            foreach (string error in result.Errors)
        //            {
        //                this.ModelState.AddModelError(string.Empty, error);
        //            }
        //        }

        //        if (this.ModelState.IsValid)
        //        {
        //            // No ModelState errors are available to send, so just return an empty BadRequest.
        //            return this.BadRequest();
        //        }

        //        return this.BadRequest(this.ModelState);
        //    }

        //    return null;
        //}

        //private class ExternalLoginData
        //{
        //    public string LoginProvider { get; set; }
        //    public string ProviderKey { get; set; }
        //    public string UserName { get; set; }

        //    public IList<Claim> GetClaims()
        //    {
        //        IList<Claim> claims = new List<Claim>();
        //        claims.Add(new Claim(ClaimTypes.NameIdentifier, this.ProviderKey, null, this.LoginProvider));

        //        if (this.UserName != null)
        //        {
        //            claims.Add(new Claim(ClaimTypes.Name, this.UserName, null, this.LoginProvider));
        //        }

        //        return claims;
        //    }

        //    public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
        //    {
        //        if (identity == null)
        //        {
        //            return null;
        //        }

        //        Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

        //        if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer)
        //            || String.IsNullOrEmpty(providerKeyClaim.Value))
        //        {
        //            return null;
        //        }

        //        if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
        //        {
        //            return null;
        //        }

        //        return new ExternalLoginData
        //        {
        //            LoginProvider = providerKeyClaim.Issuer,
        //            ProviderKey = providerKeyClaim.Value,
        //            UserName = identity.FindFirstValue(ClaimTypes.Name)
        //        };
        //    }
        //}

        //private static class RandomOAuthStateGenerator
        //{
        //    private static RandomNumberGenerator _random = new RNGCryptoServiceProvider();

        //    public static string Generate(int strengthInBits)
        //    {
        //        const int BitsPerByte = 8;

        //        if (strengthInBits % BitsPerByte != 0)
        //        {
        //            throw new ArgumentException("strengthInBits must be evenly divisible by 8.", "strengthInBits");
        //        }

        //        int strengthInBytes = strengthInBits / BitsPerByte;

        //        byte[] data = new byte[strengthInBytes];
        //        _random.GetBytes(data);
        //        return HttpServerUtility.UrlTokenEncode(data);
        //    }
        //}

        //#endregion
    }
}
