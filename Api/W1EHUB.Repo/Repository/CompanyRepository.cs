using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public async Task<Company> GetByIdWithStaffMembersAsync(int id)
        {
            var company = await _context.Companies
                .Where(company => company.Id == id)
                .Include(company => company.StaffMembers)
                .Include(company => company.Category)
                .Include(company => company.Projects)
                .FirstOrDefaultAsync();
            return company;
        }
        
        public async Task<Company> GetByIdWithProgramsAsync(int id)
        {
            var company = await _context.Companies
                .Where(company => company.Id == id)
                .Include(company => company.Category)
                .Include(company => company.Programs)
                .FirstOrDefaultAsync();
            return company;
        }

        public async Task<IEnumerable<CompanyDto>> SearchCompanyAsync(string[]? countryNames, string[]? regionNames, int[]? categoryId, string? company, string? website)
        {
            var query = _context.Companies
                .Include(c => c.Category)
                .GroupJoin(
                    _context.FavoriteCompanies,
                    company => company.Id,
                    favoriteCompany => favoriteCompany.CompanyId,
                    (company, favoriteCompanies) => new { Company = company, Favorites = favoriteCompanies.DefaultIfEmpty() }
                )
                .SelectMany(
                    x => x.Favorites,
                    (company, favorite) => new CompanyDto
                    {
                        Id = company.Company.Id,
                        Name = company.Company.Name,
                        Country = company.Company.Country,
                        Region = company.Company.Region,
                        Website = company.Company.Website,
                        CategoryId = company.Company.CategoryId,
                        CategoryName = company.Company!.Category.Name,
                        Description = company.Company.Description,
                        CompanyType = company.Company.CompanyType,
                        OldDetail = company.Company.OldDetail,
                        FavoriteIds = string.Join(",", company.Favorites
                                                    .Where(f => f != null)
                                                    .Select(f => f.Id)
                                                    .ToArray())
                    }
                )
                .AsQueryable(); // Create the base query

            // Apply filters based on parameters
            if (countryNames != null && countryNames.Any())
            {
                query = query.Where(s => countryNames.Contains(s.Country));
            }

            if (regionNames != null && regionNames.Any())
            {
                query = query.Where(s => regionNames.Contains(s.Region));
            }

            if (categoryId != null && categoryId.Any())
            {
                query = query.Where(s => categoryId.ToList().Contains((int)s.CategoryId));
            }

            if (company != null && company.Any())
            {
                query = query.Where(s => s.Name.StartsWith(company) || s.Region.StartsWith(company) || s.Country.StartsWith(company));
            }

            if (!string.IsNullOrEmpty(website))
            {
                query = query.Where(s => s.Website.Contains(website));
            }

            return await query.ToListAsync();
        }


    }
}
