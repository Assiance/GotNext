using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GotNext.Data.Repositories.Interfaces;
using GotNext.Domain.Managers.Interfaces;
using GotNext.Model.Models.Domain;

namespace GotNext.Domain.Managers
{
    public class LogManager : ILogManager
    {
        private readonly ILogActionRepository _logActionRepository;

        public LogManager(ILogActionRepository logActionRepository)
        {
            _logActionRepository = logActionRepository;
        }

        public void LogControllerAction(LogAction logAction)
        {
            _logActionRepository.LogTheAction(logAction);
        }
    }
}
