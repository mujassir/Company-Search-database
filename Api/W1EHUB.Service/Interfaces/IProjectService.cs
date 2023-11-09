using W1EHUB.Core.Dtos;
using W1EHUB.Core.Model;

namespace W1EHUB.Service.Interfaces
{
    public interface IProjectService: IGenericService<Project>
    {
        Task<IEnumerable<CompanyProjectDto>> GetAllWithCompanyAsync();
    }
}
