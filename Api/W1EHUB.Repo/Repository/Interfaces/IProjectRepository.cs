using W1EHUB.Core.Dtos;
using W1EHUB.Core.Model;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Repo.Repository.Interfaces
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Task<IEnumerable<Project>> GetAllWithCompanyAsync();
        Task<IEnumerable<Project>> SearchWithCompanyAsync(String? Country, String? TypeOfCompany, String? Region);
    }
}
