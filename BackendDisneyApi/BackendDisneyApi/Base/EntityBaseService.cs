
using BackendDisneyApi.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BackendDisneyApi.Services.Implements
{
    public class EntityBaseService<TEntity> : IEntityBaseService<TEntity> where TEntity : class
    {
        private readonly Base.IEntityBaseRepository<TEntity>_repository;

        public EntityBaseService(Base.IEntityBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public Task DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}

