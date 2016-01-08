using System.Data;
using System.Data.Entity;
using System.Web;
using GotNext.Core.Tasks;
using GotNext.Domain.Services.Interfaces;
using GotNext.Web.Infrastructure.Tasks;

namespace GotNext.Web.Infrastructure
{
    public class TransactionPerRequest : IRunOnEachRequest, IRunOnError, IRunAfterEachRequest
    {
        public static string TransactionKey { get { return "_Transaction"; } }
        public static string ErrorKey { get { return "_Error"; } }

        private readonly IApplicationDbService _applicationDbService;
        private readonly HttpContextBase _httpContext;

        public TransactionPerRequest(IApplicationDbService applicationDbService,
            HttpContextBase httpContext)
        {
            //Todo: Add all Contexts to this file
            this._applicationDbService = applicationDbService;
            this._httpContext = httpContext;
        }

        void IRunOnEachRequest.Execute()
        {
            _httpContext.Items[TransactionKey] = _applicationDbService.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        void IRunOnError.Execute()
        {
            _httpContext.Items[ErrorKey] = true;
        }

        void IRunAfterEachRequest.Execute()
        {
            var transaction = (DbContextTransaction)_httpContext.Items[TransactionKey];

            if (_httpContext.Items[ErrorKey] != null)
            {
                transaction.Rollback();
            }
            else
            {
                transaction.Commit();
            }
        }
    }
}