using Domain.Dto.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.Employer
{
    public interface IAddJobService
    {
        Task<ServiceResponse<List<DropDown>>> GetCatgories();
    }
}
