using W1EHUB.Core.Dtos;
using W1EHUB.Core.Model;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Repo.Repository.Interfaces
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<IEnumerable<Company>> GetAllWithStaffMembersAsync();
        Task<Company> GetByIdWithStaffMembersAsync(int id);
        Task<Company> GetByIdWithProgramsAsync(int id);
        Task<IEnumerable<CompanyDto>> SearchCompanyAsync(string[]? countryNames, string[]? regionNames, int[]? categoryId, string? company, string? website);
    }
}
