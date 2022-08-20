using Microsoft.AspNetCore.Identity;

namespace BackendDisneyApi.Models
{

    public class User : IdentityUser
    {
        public bool IsActive { get; set; }

    }

}
