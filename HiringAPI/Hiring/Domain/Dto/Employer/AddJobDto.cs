using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto.Employer
{
    public class AddJobDto
    {
        public string JobTitle { get; set; }
        public DateTime ClosedDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Requirement { get; set; }
        public string JobType { get; set; }
        public string? Email { get; set; }
        public string? Language { get; set; }
        public string? Salary { get; set; }
        public string? Website { get; set; }
        public Guid JobCategoryId{ get; set; }
    }
}
