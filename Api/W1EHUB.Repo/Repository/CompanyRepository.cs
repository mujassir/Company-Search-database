using Microsoft.EntityFrameworkCore;
using W1EHUB.Core.Dtos;
using W1EHUB.Core.Model;
using W1EHUB.Repo.Data;
using W1EHUB.Repo.Repository.Interfaces;
using W1EHUB.Service.Services;

namespace W1EHUB.Repo.Repository
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        private readonly RepositoryContext _context;
        public CompanyRepository(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetAllWithStaffMembersAsync()
        {
            return await _context.Companies
                .Include(company => company.StaffMembers)
                .ToListAsync();
        }
        public async Task<IEnumerable<Company>> SearchCompanyAsync(string? country, string? company, string? website, int? categoryId)
        {
            return await _context.Companies
                .Include(c => c.Category)
                .Where(s =>
                    (string.IsNullOrEmpty(country) || s.Country == country) &&
                    (string.IsNullOrEmpty(company) || s.Name == company) &&
                    (categoryId == null || s.CategoryId == categoryId) &&
                    (string.IsNullOrEmpty(website) || s.Website == website))
                .ToListAsync();
        }
    }
}
