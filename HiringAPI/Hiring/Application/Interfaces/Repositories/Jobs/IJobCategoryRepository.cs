using Application.Interfaces.Repositories.General;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.Jobs
{
    public interface IJobCategoryRepository:IBaseRepository<JobCategory>
    {
        int GetJobCount(Guid id);
    }
}
