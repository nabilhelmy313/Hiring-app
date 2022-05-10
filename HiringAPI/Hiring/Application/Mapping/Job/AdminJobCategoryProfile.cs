using Domain.Dto.Job.Admin;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping.Job
{
    public class AdminJobCategoryProfile:MappingProfileBase
    {
        public AdminJobCategoryProfile()
        {
            CreateMap<JobCategory,CreatejobCategoryDto>()
                .ForMember(a=>a.CategoryPic,a=>a.Ignore())
                .ReverseMap();
            CreateMap<JobCategory, GetJobCategoriesDto>()
               .ForMember(a => a.CategoryPic, a => a.Ignore())
               .ReverseMap();

        }
    }
}
