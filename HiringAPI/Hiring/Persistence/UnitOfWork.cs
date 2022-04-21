using Application.Interfaces.Repositories;
using Application.Interfaces.Repositories.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HiringDbContext _dbContext;

        public UnitOfWork(HiringDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CommitAsync()
        {
           return await _dbContext.SaveChangesAsync();
        }
    }
}
