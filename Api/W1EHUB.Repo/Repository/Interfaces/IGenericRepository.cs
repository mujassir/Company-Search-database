using System.Linq.Expressions;

namespace W1EHUB.Service.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(object id);
        void Add(T entity);
        void Update(T entity);
        void Delete(object id);
        Task SaveAsync();
    }
}
