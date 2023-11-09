using W1EHUB.Core.Dtos;
using W1EHUB.Core.Model;

namespace W1EHUB.Service.Interfaces
{
    public interface IProgramService: IGenericService<Program>
    {
        Task<IEnumerable<CompanyProgramDto>> GetAllWithCompanyAsync();
    }
}
