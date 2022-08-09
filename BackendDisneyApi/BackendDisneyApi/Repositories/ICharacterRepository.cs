using BackendDisneyApi.Base;
using BackendDisneyApi.Models;
using BackendDisneyApi.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendDisneyApi.Repositories
{
    public interface ICharacterRepository : IEntityBaseRepository<Character>
    {
        Task<IEnumerable<GetCharList>> GetAll();
        Task<Character> GetDetails(int id);
        IQueryable<Character> GetByName(string name);
        IQueryable<Character> CharFilter(int age, float weight, int movieId);
        Task CreateChar(CreateChar model);
        Task UpdateChar(UpdateChar model);
        bool Exists(string name);
        bool Exists(int id);
    }
}
