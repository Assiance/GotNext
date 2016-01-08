using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace GotNext.Data.Contexts
{
    public sealed class DataContext : IDataContext
    {
        private ApplicationDbContext _dbContext;

        public DataContext(ApplicationDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            _dbContext = dbContext;
        }

        public void CommitChanges()
        {
            _dbContext.SaveChanges();
        }

        public IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : class
        {
            return _dbContext.Set<TEntity>();
        }

        public void Upsert<TEntity>(TEntity entity, bool commitImmediately = true)
            where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Set<TEntity>().AddOrUpdate(entity);

            if (commitImmediately)
            {
                CommitChanges();
            }
        }

        public void Remove<TEntity>(TEntity entity, bool commitImmediately = true)
            where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Set<TEntity>().Remove(entity);

            if (commitImmediately)
            {
                CommitChanges();
            }
        }

        public DbContextTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return _dbContext.Database.BeginTransaction(isolationLevel);
        }

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
        }
    }
}
