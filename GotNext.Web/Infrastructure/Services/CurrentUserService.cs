using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using GotNext.Domain.Managers.Interfaces;
using GotNext.Model.Models.Domain;
using GotNext.Web.Infrastructure.Services.Interfaces;
using Microsoft.AspNet.Identity;

namespace GotNext.Web.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IIdentity _identity;
        private readonly IMemberManager _memberManager;

        public CurrentUserService(IIdentity identity, IMemberManager memberManager)
        {
            _identity = identity;
            _memberManager = memberManager;
        }

        public User GetCurrentUser()
        {
            var userId = _identity.GetUserId();
            if (string.IsNullOrWhiteSpace(userId))
            {
                return null;
            }

            return _memberManager.GetUserById(userId);
        }
    }
}