using BackendDisneyApi.Base;
using BackendDisneyApi.Models;
using BackendDisneyApi.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendDisneyApi.Repositories
{
    public interface IMovieRepository : IEntityBaseRepository<MovieOrSerie>
    {
        Task<IEnumerable<GetMovieDetails>> GetAll();
        Task<MovieOrSerie> GetDetails(int id);
        IQueryable<MovieOrSerie> GetByName(string name);
        IQueryable<MovieOrSerie> MovieFilter(string genre);
        Task CreateMovie(CreateMovie model);
        Task UpdateMovie(UpdateMovie model);
        bool Exists(string name);
        bool Exists(int id);
    }
}
