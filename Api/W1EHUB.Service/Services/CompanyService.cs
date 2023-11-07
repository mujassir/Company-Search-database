using W1EHUB.Core.Dtos;
using W1EHUB.Core.Model;
using W1EHUB.Repo.Repository;
using W1EHUB.Repo.Repository.Interfaces;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Service.Services
{
    public class CompanyService : GenericService<Company>, ICompanyService
    {
        private ICompanyRepository _companyRepository;
        public CompanyService(IGenericRepository<Company> repo, ICompanyRepository companyRepository) : base(repo)
        {
            _companyRepository = companyRepository;
        }
        public async Task<IEnumerable<CompanyDto>> SearchCompanyAsync(string? country, string? region, int[] categoryId, string? company, string? website)
        {
            var data = await _companyRepository.SearchCompanyAsync(country, region, categoryId, company, website);
            return data.Select(c => new CompanyDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    CategoryId = c.CategoryId,
                    Country = c.Country,
                    Region = c.Region,
                    Website = c.Website,
                    Type = c.Type,
                    CategoryName = c.Category.Name
                })
                .ToList();
        }
        public async Task<IEnumerable<Company>> GetAllWithStaffMembersAsync()
        {
            var companies = await _companyRepository.GetAllWithStaffMembersAsync();
            return companies.Select(company => new Company
            {
                Name = company.Name,
                // Map other properties
                StaffMembers = company.StaffMembers.Select(staff => new StaffMember
                {
                    Name = staff.Name,
                    Role = staff.Role
                }).ToList()
            }).ToList();
        }

        public async Task<CompanyDto> GetByIdWithStaffMembersAsync(int id)
        {
            var company = await _companyRepository.GetByIdWithStaffMembersAsync(id);
            return new CompanyDto
            {
                Id = company.Id,
                Name = company.Name,
                Description = company.Description,
                Country = company.Country,
                Region = company.Region,
                Website = company.Website,
                Type = company.Type,
                OldDetail = company.OldDetail,
                CategoryId = company.CategoryId,
                CategoryName = company.Category.Name,
                StaffMembers = company.StaffMembers.Select(member => new CompanyStaffMemberDto
                {
                    Id = member.Id,
                    Name = member.Name,
                    Role = member.Role,
                    Email = member.Email,
                    Phone = member.Phone,
                    CompanyId = member.CompanyId,
                }).ToList()
            };
        }
    }
}
