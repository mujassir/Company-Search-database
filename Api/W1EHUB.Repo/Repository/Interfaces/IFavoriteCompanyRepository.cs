using W1EHUB.Core.Model;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Repo.Repository.Interfaces
{
    public interface IFavoriteCompanyRepository : IGenericRepository<FavoriteCompany>
    {
        Task<IEnumerable<FavoriteCompany>> GetFavoriteCompaniesByIdAsync(int id);
    }
}
