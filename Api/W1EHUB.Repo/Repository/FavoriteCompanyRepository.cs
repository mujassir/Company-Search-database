using Microsoft.EntityFrameworkCore;
using W1EHUB.Core.Model;
using W1EHUB.Repo.Data;
using W1EHUB.Repo.Repository.Interfaces;
using W1EHUB.Service.Services;

namespace W1EHUB.Repo.Repository
{
    public class FavoriteCompanyRepository : GenericRepository<FavoriteCompany>, IFavoriteCompanyRepository
    {
        private readonly RepositoryContext _context;
        public FavoriteCompanyRepository(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FavoriteCompany>> GetFavoriteCompaniesByIdAsync(int id)
        {
            return await _context.FavoriteCompany
                .Where(f => f.FavoriteId == id)
                .Include(a => a.Company)
                .Include(a => a.Favorite)
                .ToListAsync();
        }
    }
}
