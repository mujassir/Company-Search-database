using W1EHUB.Core.Dtos;
using W1EHUB.Core.Model;

namespace W1EHUB.Service.Interfaces
{
    public interface ICompanyService: IGenericService<Company>
    {
        Task<IEnumerable<Company>> GetAllWithStaffMembersAsync();
        Task<IEnumerable<CompanyDto>> SearchCompanyAsync(string? country, string? company, string? website, int? categoryId);
    }
}
