using Domain.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto.General.Auth
{
    public class RegisterDto
    {
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is Requried")]
        [ValidatePassword()]
        public string? Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Not Match")]
        public string? ConfirmPassword { get; set; }
        [Required]
        public string? Role { get; set; }
    }
}
