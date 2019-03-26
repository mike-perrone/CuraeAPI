using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FiralApiReal.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        [EmailAddress]
        public string  Username { get; set; }

        [Required]
        [StringLength(22, MinimumLength = 7, ErrorMessage = "Password has to be longer than six characers.")]
        public string Password { get; set; }
    }
}
