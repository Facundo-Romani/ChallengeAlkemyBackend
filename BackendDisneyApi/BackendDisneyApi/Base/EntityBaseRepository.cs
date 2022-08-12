using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using BackendDisneyApi.DataAccess;

namespace BackendDisneyApi.Base
{
    public class EntityBaseRepository<TEntity> : IEntityBaseRepository<TEntity> where TEntity : class
    {

        private readonly DisneyDBContext _context;

        public EntityBaseRepository(DisneyDBContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            EntityEntry entityEntry = _context.Entry<TEntity>(entity);
            entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        } 

        public async Task<IEnumerable<TEntity>> GetAllAsync() =>
            await _context.Set<TEntity>().ToListAsync();
    }
}
