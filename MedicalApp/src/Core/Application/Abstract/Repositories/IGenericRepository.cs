
using Domain;
using System.Linq.Expressions;

namespace Application.Abstract.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);
        Task<bool> AddAsync(T entity);
        Task<int> SaveChangesAsync();
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

    }
}
