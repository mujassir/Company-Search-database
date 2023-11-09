using W1EHUB.Core.Dtos;
using W1EHUB.Core.Model;

namespace W1EHUB.Service.Interfaces
{
    public interface ICompanyService: IGenericService<Company>
    {
        Task<IEnumerable<Company>> GetAllWithStaffMembersAsync();
        Task<CompanyDto> GetByIdWithStaffMembersAsync(int id);
        Task<CompanyDto> GetByIdWithProgramsAsync(int id);
        Task<IEnumerable<CompanyDto>> SearchCompanyAsync(string? country, string? region, int[] categoryId, string? company, string? website);
    }
}
