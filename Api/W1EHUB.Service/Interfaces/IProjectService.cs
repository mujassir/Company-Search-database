using W1EHUB.Core.Dtos;
using W1EHUB.Core.Model;

namespace W1EHUB.Service.Interfaces
{
    public interface IProjectService : IGenericService<Project>
    {
        Task<IEnumerable<ProjectDto>> GetAllWithCompanyAsync();
        Task<IEnumerable<ProjectDto>> SearchWithCompanyAsync(String? Country, String? TypeOfCompany, String? Region);
    }
}
