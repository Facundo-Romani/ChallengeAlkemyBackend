using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace BackendDisneyApi.ViewModels.Auth.Login
{
    public class LoginViewModel
    {
        [Required]
        [MinLength(6)]

        public string Username { get; set; }

        [Required]
        [MinLength(6)]

        public string Password { get; set; }
    }
}
