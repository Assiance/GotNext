using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GotNext.Data.Contexts;
using GotNext.Data.Entities;
using GotNext.Data.Repositories.Interfaces;
using GotNext.Model.Models.Domain;

namespace GotNext.Data.Repositories
{
    public class LogActionRepository : ILogActionRepository
    {
        private readonly IDataContext _dataContext;

        public LogActionRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void LogTheAction(LogAction logAction)
        {
            var logActionEntity = Mapper.Map<LogActionEntity>(logAction);

            try
            {
                _dataContext.Upsert(logActionEntity);
            }
            catch (Exception)
            {
                throw new ArgumentException(nameof(logActionEntity));
            }
        }
    }
}
