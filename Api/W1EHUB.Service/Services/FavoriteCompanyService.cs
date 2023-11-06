using W1EHUB.Core.Model;
using W1EHUB.Repo.Repository.Interfaces;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Service.Services
{
    public class FavoriteCompanyService: GenericService<FavoriteCompany>, IFavoriteCompanyService
    {
        private readonly IFavoriteCompanyRepository _favoriteRepository;
        public FavoriteCompanyService(IGenericRepository<FavoriteCompany> repo, IFavoriteCompanyRepository favoriteRepository) : base(repo)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task<IEnumerable<FavoriteCompany>> GetFavoriteCompaniesByIdAsync(int userId, int companyId)
        {
            return await _favoriteRepository.GetFavoriteCompaniesByIdAsync(userId, companyId);
        }
    }
}
