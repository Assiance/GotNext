using GotNext.Model.Models.Domain;

namespace GotNext.Domain.Managers.Interfaces
{
    public interface ILogManager
    {
        void LogControllerAction(LogAction logAction);
    }
}