using Microsoft.EntityFrameworkCore;
using W1EHUB.Core.Model;
using W1EHUB.Repo.Data;
using W1EHUB.Repo.Repository.Interfaces;
using W1EHUB.Service.Services;

namespace W1EHUB.Repo.Repository
{
    public class ProgramRepository : GenericRepository<Program>, IProgramRepository
    {
        private readonly RepositoryContext _context;
        public ProgramRepository(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Program>> GetAllWithCompanyAsync()
        {
            return await _context.Programs
               .Include(a => a.Company)
               .ToListAsync();
        }
    }
}
