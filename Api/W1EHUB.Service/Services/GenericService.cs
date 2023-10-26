using Microsoft.EntityFrameworkCore;
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

        protected IGenericRepository<T> Repo
        {
            get { return _repo; }
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repo.FindByAsync(predicate);
        }

        public async Task<T> GetAsync(object id)
        {
            return await _repo.GetAsync(id);
        }

        public void Add(T entity)
        {
            _repo.Add(entity);
        }

        public void Update(T entity)
        {
            _repo.Update(entity);
        }

        public void Delete(object id)
        {
           _repo.Delete(id);
        }

    }
}
