using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GotNext.Data.Contexts;
using GotNext.Domain.Services.Interfaces;

namespace GotNext.Domain.Services
{
    public class ApplicationDbService : IApplicationDbService
    {
        private readonly IDataContext _context;

        public ApplicationDbService(IDataContext context)
        {
            _context = context;
        }

        public DbContextTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return _context.BeginTransaction(isolationLevel);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
