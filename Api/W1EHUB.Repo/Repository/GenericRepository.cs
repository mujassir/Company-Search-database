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

        protected DbSet<T> DbSet
        {
            get { return _dbSet; }
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T> GetAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T entity = _dbSet.Find(id);
            if (entity != null)
                _dbSet.Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

    
}
