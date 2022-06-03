using Application.Interfaces.Repositories.Jobs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Admin
{
    public class JobCategoryRepository:BaseRepository<JobCategory>,IJobCategoryRepository
    {
        public JobCategoryRepository(HiringDbContext dbContext) : base(dbContext)
        {

        }
        public int GetJobCount(Guid id)
        {
            int job = _dbContext.Jobs.Where(j => j.JobCategory.Id == id).Count();
            return job;
        }

    }
}
