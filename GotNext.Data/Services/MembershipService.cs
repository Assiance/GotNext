using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GotNext.Data.Contexts;
using GotNext.Data.Entities.User;
using GotNext.Data.Repositories;
using GotNext.Data.Services.Interfaces;
using GotNext.Model.Models.Domain;
using GotNext.Model.Models.Domain.Account;
using GotNext.Model.Models.Domain.Authentication;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace GotNext.Data.Services
{
    public class MembershipService : SignInManager<ApplicationUserEntity, string>, IMembershipService
    {
        private readonly IDataContext _dataContext;

        public MembershipService(IDataContext dataContext, ApplicationUserRepository userRepository, IAuthenticationManager authenticationManager)
            : base(userRepository, authenticationManager)
        {
            _dataContext = dataContext;
        }

        private IQueryable<ApplicationUserEntity> UsersCompleteQuery
        {
            get
            {
                return UserManager.Users;
            }  
        } 

        public User GetById(string id)
        {
            var user = UsersCompleteQuery.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return null;
            }

            return Mapper.Map<User>(user);
        }

        public async Task<RegistrationResult> RegisterAndSignInAsync(Registration registration)
        {
            if (registration == null)
            {
                throw new ArgumentNullException(nameof(registration));
            }

            var result = new RegistrationResult();

            var user = Mapper.Map<ApplicationUserEntity>(registration);
            user.UserName = registration.Email;

            var createResult = await UserManager.CreateAsync(user, registration.Password);

            if (!createResult.Succeeded)
            {
                result.ErrorMessages = createResult.Errors.ToList();
                return result;
            }

            await SignInAsync(user, isPersistent: false, rememberBrowser: false);

            return result;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await UserManager.FindByEmailAsync(email);

            if (user == null)
            {
                return null;
            }

            return Mapper.Map<User>(user);
        }
    }
}
