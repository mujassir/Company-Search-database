using Microsoft.EntityFrameworkCore;
using W1EHUB.Core.Dtos;
using W1EHUB.Core.Model;
using W1EHUB.Repo.Data;
using W1EHUB.Repo.Repository.Interfaces;
using W1EHUB.Service.Services;

namespace W1EHUB.Repo.Repository
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Project>> GetAllWithCompanyAsync()
        {
            return await DbSet
                .Include(project => project.Company)
                .ToListAsync();
        }

        public async Task<IEnumerable<Project>> SearchWithCompanyAsync(string? Country, string? TypeOfCompany, string? Region)
        {
            var query = DbSet
                .Include(project => project.Company)
                .Where(p =>
                    (string.IsNullOrEmpty(Country) || p.Company.Country.Contains(Country)) &&
                    (string.IsNullOrEmpty(TypeOfCompany) || p.Company.TypeOfCompany.Contains(TypeOfCompany)) &&
                    (string.IsNullOrEmpty(Region) || p.Company.Region.Contains(Region))
                );

            return await query.ToListAsync();
        }

    }
}
