using BackendDisneyApi.Base;
using BackendDisneyApi.Models;
using BackendDisneyApi.Repositories.Users;
using IdentityServer3.Core.Services;

namespace BackendDisneyApi.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            this._userRepository = userRepository;
        }
    }
}
