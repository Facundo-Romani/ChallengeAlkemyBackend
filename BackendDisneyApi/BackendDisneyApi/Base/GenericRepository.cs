using BackendDisneyApi.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BackendDisneyApi.Base
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DisneyDBContext _DisneyDBContext;

        public GenericRepository(DisneyDBContext DisneyDBContext)
        {
            this._DisneyDBContext = DisneyDBContext;
        }

        // DELETE
        public async Task Delete(int id)
        {
            try
            {
                var entity = await GetById(id);

                if (entity == null)
                {
                    throw new Exception("The entity is null");
                }
                else
                {
                    _DisneyDBContext.Set<TEntity>().Remove(entity);
                    await _DisneyDBContext.SaveChangesAsync();
                }
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET ALL 
        public async Task<List<TEntity>> GetAll()
        {
            try
            {
                return await _DisneyDBContext.Set<TEntity>().ToListAsync();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET BY ID 
        public async Task<TEntity> GetById(int id)
        {
            try
            {
                return await _DisneyDBContext.Set<TEntity>().FindAsync(id);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // INSERT
        public async Task<TEntity> Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                await _DisneyDBContext.Set<TEntity>().AddAsync(entity);
                await _DisneyDBContext.SaveChangesAsync();
                return entity;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // UPDATE
        public async Task<TEntity> Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _DisneyDBContext.Set<TEntity>().Update(entity);
                await _DisneyDBContext.SaveChangesAsync();
                return entity;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
