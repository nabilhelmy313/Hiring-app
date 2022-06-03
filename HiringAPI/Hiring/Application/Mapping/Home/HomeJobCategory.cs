using Domain.Dto.Home;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping.Home
{
    public class HomeJobCategory:MappingProfileBase
    {
        public HomeJobCategory()
        {
            CreateMap<JobCategory, GetHomeJobCategoriesDto>()
               .ReverseMap();
        }
    }
}
