using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendDisneyApi.Base
{
    public interface IEntityBaseService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
