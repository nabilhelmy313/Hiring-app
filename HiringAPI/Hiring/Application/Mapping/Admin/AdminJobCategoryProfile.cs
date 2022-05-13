using Domain.Dto.Admin;
using Domain.Dto.JobAdmin.Admin;
using Domain.Entities;
using Domain.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping.Admin
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



            CreateMap<ApplicationUser, GetEmployerInfoDto>()
               .ForMember(a => a.UserId, a => a.MapFrom(a=>a.Id))
                .ReverseMap() ;
               
                 

        }
    }
}
