using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace eTicket.Data.Base
{
    public class EntityBaseRepositoty<T> : IEntityBaseRepositoty<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext dbcontext;
        public EntityBaseRepositoty(AppDbContext context)
        {
            dbcontext = context;
        }

        public async Task AddAsync(T entity)
        {
            await dbcontext.Set<T>().AddAsync(entity);
            await dbcontext.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var result = dbcontext.Set<T>().FirstOrDefault(x => x.Id == id);
            EntityEntry entityEntry = dbcontext.Entry<T>(result);
            entityEntry.State = EntityState.Deleted;
            await dbcontext.SaveChangesAsync();

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await dbcontext.Set<T>().ToListAsync();
            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] expressions)
        {
            IQueryable<T> query = dbcontext.Set<T>();
            query = expressions.Aggregate(query,(current,expressions) => current.Include(expressions));
            return await query.ToListAsync();
        }

        public async Task<T> GetAllById(int id)
        {
            var result = await dbcontext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task UpdateAync(int id, T entity)
        {
            EntityEntry entityEntry= dbcontext.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await dbcontext.SaveChangesAsync();
        }
    }
}

