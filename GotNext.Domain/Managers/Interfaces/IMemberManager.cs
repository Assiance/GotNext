using GotNext.Model.Models.Domain;

namespace GotNext.Domain.Managers.Interfaces
{
    public interface IMemberManager
    {
        User GetUserById(string userId);
    }
}