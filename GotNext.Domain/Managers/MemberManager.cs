using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GotNext.Data.Services.Interfaces;
using GotNext.Domain.Managers.Interfaces;
using GotNext.Model.Models.Domain;
using GotNext.Model.Models.Domain.Account;
using GotNext.Model.Models.Domain.Authentication;

namespace GotNext.Domain.Managers
{
    public class MemberManager : IMemberManager
    {
        private readonly IMembershipService _membershipService;

        public MemberManager(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        public User GetUserById(string userId)
        {
            return _membershipService.GetById(userId);
        }

        public async Task<RegistrationResult> RegisterAndSignInAsync(Registration registration)
        {
            if (registration == null)
            {
                throw new ArgumentNullException(nameof(registration));
            }

            var user = await _membershipService.GetUserByEmailAsync(registration.Email);

            if (user != null)
            {
                var errorResult = new RegistrationResult();

                errorResult.ErrorMessages.Add("Email " + registration.Email + " has already been taken."); //TODO: Translation
                return errorResult;
            }

            var result = await _membershipService.RegisterAndSignInAsync(registration);

            return result;
        }
    }
}
