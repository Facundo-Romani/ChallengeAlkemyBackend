using BackendDisneyApi.Base;
using BackendDisneyApi.Models;
using BackendDisneyApi.ViewModels;

namespace BackendDisneyApi.Services
{
    public interface ICharacterService : IEntityBaseService<Character>
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
