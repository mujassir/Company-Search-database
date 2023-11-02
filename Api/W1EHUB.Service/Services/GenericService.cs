using System.Linq.Expressions;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Service.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _repo;

        public GenericService(IGenericRepository<T> repo)
        {
            _repo = repo;
        }

        public async Task<bool> Any(Expression<Func<T, bool>> expression)
        {
            return await _repo.Any(expression);
        }

        public async Task<T?> Find(T entity)
        {
            return await _repo.Find(entity);
        }
        public async Task<T?> Find(object id)
        {
            return await _repo.Find(id);
        }
        public async Task<IQueryable<T>> FindAll(bool hasChangesTracked)
        {
            return await _repo.FindAll(hasChangesTracked);
        }
        public async Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression, bool hasChangesTracked)
        {
            return await _repo.FindByCondition(expression, hasChangesTracked);
        }
        public async Task<T> Create(T entity)
        {
            return await _repo.Create(entity);
        }
        public async Task Create(T[] entities)
        {
            await _repo.Create(entities);
        }
        public async Task<T> Update(T entity)
        {
            return await _repo.Update(entity);
        }
        public void UpdateChanges(T entity)
        {
            _repo.UpdateChanges(entity);
        }
        public async Task Update(T[] entities) => await _repo.Update(entities);
        public async Task<T> Delete(T entity)
        {
            return await _repo.Delete(entity);
        }
        public async Task Delete(T[] entities) => await _repo.Update(entities);

        public async Task Save()
        {
            await _repo.Save();
        }
    }
}
