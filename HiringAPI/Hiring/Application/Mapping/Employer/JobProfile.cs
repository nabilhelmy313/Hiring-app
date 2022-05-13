using Domain.Dto.Employer;
using Domain.Entities;



namespace Application.Mapping.Employer
{
    public class JobProfile:MappingProfileBase
    {
        public JobProfile()
        {
            CreateMap<Job, AddJobDto>()
                .ForMember(a=>a.JobCategoryId,a=>a.Ignore())
                .ReverseMap();
        }
    }
}
