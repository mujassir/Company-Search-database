using W1EHUB.Core.Model;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Repo.Repository.Interfaces
{
    public interface IStaffMemberRepository : IGenericRepository<StaffMember>
    {
        Task<IEnumerable<StaffMember>> GetAllWithCompanyAsync();
        Task<IEnumerable<StaffMember>> SearchAllWithCompanyAsync(string? role, string? country, string? company, string? website, int? categoryId);
    }
}
