using System.Threading.Tasks;
using GotNext.Model.Models.Domain;
using GotNext.Model.Models.Domain.Authentication;

namespace GotNext.Data.Services.Interfaces
{
    public interface IMembershipService
    {
        User GetById(string id);
        Task<RegistrationResult> RegisterAndSignInAsync(Registration registration);
        Task<User> GetUserByEmailAsync(string email);
    }
}