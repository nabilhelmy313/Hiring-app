using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto.General.Auth
{
    public class TokenDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public UserDto CurrentUser { get; set; }
        public bool IsUserApproved { get; set; }
    }

}
