using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using W1EHUB.Repo.Data;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Service.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly RepositoryContext _context;
        private DbSet<T> _dbSet;

        public GenericRepository(RepositoryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public async Task<bool> Any(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public async Task<T?> Find(T entity)
        {
            return await Task.Run(() => _dbSet.Find(entity));
        }
        public async Task<T?> Find(object id)
        {
            return await Task.Run(() => _dbSet.Find(id));
        }
        public async Task<IQueryable<T>> FindAll(bool hasChangesTracked) =>
                hasChangesTracked ? await Task.Run(() => _dbSet) : await Task.Run(() => _dbSet.AsNoTracking());
        public async Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression, bool hasChangesTracked) =>
                hasChangesTracked ? await Task.Run(() => _dbSet.Where(expression)) : await Task.Run(() => _dbSet.Where(expression).AsNoTracking());
        public async Task<T> Create(T entity)
        {
            var entityAdded = await _dbSet.AddAsync(entity);
            return entityAdded.Entity;
        }
        public async Task Create(T[] entities) => await _dbSet.AddRangeAsync(entities);
        public async Task<T> Update(T entity)
        {
            var entityUpdated = await Task.Run(() => _dbSet.Update(entity));
            return entityUpdated.Entity;
        }
        public void UpdateChanges(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public async Task Update(T[] entities) => await Task.Run(() => _dbSet.UpdateRange(entities));
        public async Task<T> Delete(T entity)
        {
            var entityDeleted = await Task.Run(() => _dbSet.Remove(entity));
            return entityDeleted.Entity;
        }
        public async Task Delete(T[] entities) => await Task.Run(() => _dbSet.RemoveRange(entities));

        public async Task Save() => await _context.SaveChangesAsync();
    }

    
}
