using W1EHUB.Core.Model;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Repo.Repository.Interfaces
{
    public interface IProgramRepository : IGenericRepository<Program>
    {
        Task<IEnumerable<Program>> GetAllWithCompanyAsync();
    }
}
