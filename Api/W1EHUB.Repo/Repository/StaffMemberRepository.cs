using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using W1EHUB.Core.Model;
using W1EHUB.Repo.Data;
using W1EHUB.Repo.Repository.Interfaces;
using W1EHUB.Service.Services;

namespace W1EHUB.Repo.Repository
{
    public class StaffMemberRepository : GenericRepository<StaffMember>, IStaffMemberRepository
    {
        private readonly RepositoryContext _context;
        public StaffMemberRepository(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StaffMember>> GetAllWithCompanyAsync()
        {
            return await _context.StaffMembers
               .Include(a => a.Company)
               .ToListAsync();
        }
        public async Task<IEnumerable<StaffMember>> SearchAllWithCompanyAsync(string? role, string? country, string? company, string? website, int? categoryId)
        {
            return await _context.StaffMembers
               .Include(a => a.Company)
               .Where(s =>
                    (string.IsNullOrEmpty(role) || s.Role == role) &&
                    (string.IsNullOrEmpty(country) || s.Company.Country == country) &&
                    (string.IsNullOrEmpty(company) || s.Company.Name == company) &&
                    (categoryId == null || s.Company.CategoryId == categoryId) &&
                    (string.IsNullOrEmpty(website) || s.Company.Website == website))
                .ToListAsync();
        }
    }
}
