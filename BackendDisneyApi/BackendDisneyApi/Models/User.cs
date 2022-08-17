using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BackendDisneyApi.Models
{

    public class User : IdentityUser
    {
        public bool IsActive { get; set; }
    }

}
