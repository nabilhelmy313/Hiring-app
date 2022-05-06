﻿using Domain.Dto.Job.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.Job
{
    public interface IAdminJobCategoryService
    {
        Task<ServiceResponse<int>> CreateJobCategory(CreatejobCategoryDto createjobCategoryDto);
        Task<ServiceResponse<int>> DeleteJobCategory(Guid id);
    }
}
