using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto.JobAdmin.Admin
{
    public class GetJobCategoriesDto
    {
        public Guid Id { get; set; }
        public string TitleEn { get; set; }
        public string TitleFr { get; set; }
        public string Titledu { get; set; }
        public string CategoryPic { get; set; }

    }
}
