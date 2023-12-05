using W1EHUB.Core.Dtos;
using W1EHUB.Core.Model;

namespace W1EHUB.Service.Interfaces
{
    public interface IFavoriteCompanyService : IGenericService<FavoriteCompany>
    {
        Task<IEnumerable<FavoriteCompany>> GetFavoriteCompaniesByIdAsync(int userId, int companyId);
        Task<IEnumerable<CompanyDto>> GetCompaniesByFavoriteIdAsync(int favoriteId);
    }
}
