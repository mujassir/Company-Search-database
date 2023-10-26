using Microsoft.EntityFrameworkCore;
using W1EHUB.Core.Dtos;
using W1EHUB.Core.Model;
using W1EHUB.Repo.Data;
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

        public async Task<IEnumerable<CompanyDto>> GetAllWithStaffMembersAsync()
        {
            var companies = await _companyRepository.GetAllWithStaffMembersAsync();
            return companies.Select(company => new CompanyDto
            {
                Name = company.Name,
                // Map other properties
                StaffMembers = company.StaffMembers.Select(staff => new CompanyStaffMemberDto
                {
                    Name = staff.Name,
                    Role = staff.Role
                }).ToList()
            }).ToList();
        }
    }
}
