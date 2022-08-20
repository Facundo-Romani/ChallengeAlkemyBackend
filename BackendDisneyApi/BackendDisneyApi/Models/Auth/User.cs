using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BackendDisneyApi.Models.Auth
{

    public class User : IdentityUser
    {
        public bool IsActive { get; set; }

    }

}
