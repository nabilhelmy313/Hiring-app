using Domain.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto.General.Auth
{
    public class LoginDto
    {
        [Required]
        //[Required(ErrorMessageResourceName = nameof(Resources.General.LoginResources.MissingUserName), ErrorMessageResourceType = typeof(Resources.General.LoginResources))]
        public string UserName { get; set; }

        [Required]
        [ValidatePassword()]
        public string Password { get; set; }
    }
}
