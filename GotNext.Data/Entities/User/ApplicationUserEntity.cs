using System.Security.Claims;
using System.Threading.Tasks;
using GotNext.Core.Mapping;
using GotNext.Model.Models.Domain.Authentication;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GotNext.Data.Entities.User
{
    public class ApplicationUserEntity : IdentityUser, IMapFrom<Model.Models.Domain.User>, IMapTo<Model.Models.Domain.User>, IMapFrom<Registration>
    {
        // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUserEntity> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            // Add custom user claims here
            return userIdentity;
        }
    }
}