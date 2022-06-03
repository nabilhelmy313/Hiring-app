using Domain.Dto.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.Home
{
    public interface IHomeJobCategoryService
    {

        Task<ServiceResponse<List<GetHomeJobCategoriesDto>>> GetJobCategories();
    }
}
