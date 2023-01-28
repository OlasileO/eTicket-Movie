using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
namespace eTicket.Data.Base
{
    public interface IEntityBaseRepositoty<T> where T:class,IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, Object>>[] expressions);
        Task<T> GetAllById(int id);
        Task AddAsync(T entity);
        Task UpdateAync(int id,T entity);  
        Task DeleteAsync(int id);

    }
}
