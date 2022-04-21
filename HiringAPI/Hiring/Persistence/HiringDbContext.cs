using Domain.Entities.General;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class HiringDbContext: IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public HiringDbContext(DbContextOptions<HiringDbContext> options) : base(options)
        {

        }
    }
}
