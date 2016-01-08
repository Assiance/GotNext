using GotNext.Model.Models.Domain;

namespace GotNext.Data.Repositories.Interfaces
{
    public interface ILogActionRepository
    {
        void LogTheAction(LogAction logAction);
    }
}