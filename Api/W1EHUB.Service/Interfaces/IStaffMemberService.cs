using W1EHUB.Core.Dtos;
using W1EHUB.Core.Model;

namespace W1EHUB.Service.Interfaces
{
    public interface IStaffMemberService : IGenericService<StaffMember>
    {
        Task<IEnumerable<CompanyStaffMemberDto>> GetAllWithCompanyAsync();
        Task<IEnumerable<StaffWithCompanyDto>> SearchAllWithCompanyAsync(string? role, string? country, string? company, string? website, int? categoryId);
    }
}
