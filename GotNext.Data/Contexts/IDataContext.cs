using System;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace GotNext.Data.Contexts
{
    public interface IDataContext : IDisposable
    {
        void CommitChanges();

        DbContextTransaction BeginTransaction(IsolationLevel isolationLevel);

        IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : class;

        void Upsert<TEntity>(TEntity entity, bool commitImmediately = true) where TEntity : class;

        void Remove<TEntity>(TEntity entity, bool commitImmediately = true) where TEntity : class;
    }
}
