using System.Data;
using System.Data.Entity;
using GotNext.Data.Contexts;

namespace GotNext.Domain.Services.Interfaces
{
    public interface IApplicationDbService
    {
        DbContextTransaction BeginTransaction(IsolationLevel isolationLevel);
    }
}