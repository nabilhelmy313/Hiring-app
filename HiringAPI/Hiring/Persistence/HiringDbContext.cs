using Domain.Entities;
using Domain.Entities.General;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Persistence
{
    public class HiringDbContext: IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public HiringDbContext(DbContextOptions<HiringDbContext> options) : base(options)
        {

        }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<JobCategory> JobCategories{ get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}
