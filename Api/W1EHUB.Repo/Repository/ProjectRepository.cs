using Microsoft.EntityFrameworkCore;
using W1EHUB.Core.Model;
using W1EHUB.Repo.Data;
using W1EHUB.Repo.Repository.Interfaces;
using W1EHUB.Service.Services;

namespace W1EHUB.Repo.Repository
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        private readonly RepositoryContext _context;
        public ProjectRepository(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAllWithCompanyAsync()
        {
            return await _context.Projects
                .Include(a => a.Company)
                .ToListAsync();
        }
    }
}
