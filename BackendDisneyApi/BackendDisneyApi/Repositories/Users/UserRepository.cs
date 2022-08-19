using BackendDisneyApi.Base;
using BackendDisneyApi.DataAccess;
using BackendDisneyApi.Models;

namespace BackendDisneyApi.Repositories.Users
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DisneyDBContext DisneyDBContext) : base(DisneyDBContext)
        {
        }
    }
}
