
using System.Data;
using W1EHUB.Core.Dtos;
using W1EHUB.Core.Model;
using W1EHUB.Repo.Repository;
using W1EHUB.Repo.Repository.Interfaces;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Service.Services
{
    public class StaffMemberService : GenericService<StaffMember>, IStaffMemberService
    {
        private readonly IStaffMemberRepository _staffMemberRepository;

        public StaffMemberService(IStaffMemberRepository repo) : base(repo)
        {
            _staffMemberRepository = repo;
        }

        public async Task<IEnumerable<CompanyStaffMemberDto>> GetAllWithCompanyAsync()
        {
            var data = await _staffMemberRepository.GetAllWithCompanyAsync();
            return data.Select(staff => new CompanyStaffMemberDto
            {
                Id = staff.Id,
                Name = staff.Name,
                Role = staff.Role,
                Email = staff.Email,
                CompanyId = staff.CompanyId,
                Company = new CompanyDto
                {
                    Name = staff.Company.Name,
                    Country = staff.Company.Country,
                    Type = staff.Company.Type,
                    Website = staff.Company.Website,
                    CategoryId = staff.Company.CategoryId,
                }
            }).ToList();
        }

        public async Task<IEnumerable<StaffWithCompanyDto>> SearchAllWithCompanyAsync(string? role, string? country, string? company, string? website, int? categoryId)
        {
            var data = await _staffMemberRepository.SearchAllWithCompanyAsync(role, country, company, website, categoryId);
            return data.Select(staff => new StaffWithCompanyDto
            {
                Id = staff.Id,
                Name = staff.Name,
                Role = staff.Role,
                Email = staff.Email,
                CompanyId = staff.Company.Id,
                CompanyName = staff.Company.Name,
                CompanyCountry = staff.Company.Country,
                CompanyType= staff.Company.Type,
                CompanyWebsite = staff.Company.Website,
                CategoryId = staff.Company.CategoryId,
            }).ToList();
        }
    }
}
