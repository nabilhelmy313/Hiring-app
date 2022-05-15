using Application.Interfaces.Repositories.Jobs;
using Domain.Entities;


namespace Persistence.Repositories.Admin
{
    public class JobRepository:BaseRepository<Job>, IJobRepository
    {
        public JobRepository(HiringDbContext dbContext) : base(dbContext)
        {

        }
    }
}
