using System;
using GotNext.Data.Entities.User;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace GotNext.Data.Repositories
{
    public class ApplicationUserRepository : UserManager<ApplicationUserEntity>
    {
        public ApplicationUserRepository(IUserStore<ApplicationUserEntity> store, IdentityFactoryOptions<ApplicationUserRepository> options)
            : base(store)
        {
            UserValidator = new UserValidator<ApplicationUserEntity>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            PasswordValidator = new PasswordValidator()
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            // Configure user lockout defaults
            UserLockoutEnabledByDefault = true;
            DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            MaxFailedAccessAttemptsBeforeLockout = 5;

            UserTokenProvider = new DataProtectorTokenProvider<ApplicationUserEntity>(options.DataProtectionProvider.Create("ASP.NET Identity"))
            {
                // Tokens, like forgot password, are valid for this amount of time
                TokenLifespan = TimeSpan.FromHours(3)
            };
        }
    }
}
