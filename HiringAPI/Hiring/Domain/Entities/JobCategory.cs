using Domain.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class JobCategory : BaseEntity
    {
        public string Title_En { get; set; }
        public string Title_Fr { get; set; }
        public string Title_du { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}
