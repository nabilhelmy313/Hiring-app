using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.General
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public virtual ICollection<ApplicationRole> UserRoles { get; set; } = new List<ApplicationRole>();

    }
}
