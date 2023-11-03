using W1EHUB.Core.Model;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Repo.Repository.Interfaces
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<IEnumerable<Company>> GetAllWithStaffMembersAsync();
        Task<IEnumerable<Company>> SearchCompanyAsync(string? country, string? region, int? categoryId, string? company, string? website);
    }
}
