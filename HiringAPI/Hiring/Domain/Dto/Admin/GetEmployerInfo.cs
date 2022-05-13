using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto.Admin
{
    public class GetEmployerInfoDto
    {
        public Guid UserId{ get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Boolean IsActive { get; set; }
    }
}
