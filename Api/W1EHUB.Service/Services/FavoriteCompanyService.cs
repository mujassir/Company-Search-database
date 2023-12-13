using System.ComponentModel.Design;
using W1EHUB.Core.Dtos;
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
        public async Task<IEnumerable<CompanyDto>> GetCompaniesByFavoriteIdAsync(int favoriteId)
        {
            var data = await _favoriteRepository.GetCompaniesByFavoriteIdAsync(favoriteId);
            return data.Select(c => new CompanyDto
            {
                Id = c.Company.Id,
                Name = c.Company.Name,
                CategoryId = c.Company.CategoryId,
                Country = c.Company.Country,
                CompanyType = c.Company.CompanyType,
                Region = c.Company.Region,
                Website = c.Company.Website,
                Type = c.Company.Type,
                CategoryName = c.Company.Category.Name,
                FavoriteIds = c.FavoriteId.ToString()
            })
            .ToList();
        }
    }
}
