using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GotNext.Model.Models.Domain;

namespace GotNext.Web.Infrastructure.Services.Interfaces
{
    public interface ICurrentUserService
    {
        User GetCurrentUser();
    }
}
