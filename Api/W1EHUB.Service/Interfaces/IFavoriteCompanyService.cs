using W1EHUB.Core.Model;

namespace W1EHUB.Service.Interfaces
{
    public interface IFavoriteCompanyService : IGenericService<FavoriteCompany>
    {
        Task<IEnumerable<FavoriteCompany>> GetFavoriteCompaniesByIdAsync(int id);
    }
}
