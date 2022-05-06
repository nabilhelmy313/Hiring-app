using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto.Job.Admin
{
    public class CreatejobCategoryDto
    {
        public Guid? Id { get; set; }
        public string Title_En { get; set; }
        public string Title_Fr { get; set; }
        public string Title_du { get; set; }
        public IFormFile CategoryPic{ get; set; }
    }
}
