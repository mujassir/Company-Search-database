using W1EHUB.Core.Model;
using W1EHUB.Repo.Repository.Interfaces;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Service.Services
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IGenericRepository<Category> repo, ICategoryRepository categoryRepository) : base(repo)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllWithCompanyAsync()
        {
            var categories = await _categoryRepository.GetAllWithCompanyAsync();
            return categories.Select(cat => new Category
            {
                Id = cat.Id,
                Name = cat.Name,
                Companies = cat.Companies
            }).ToList();
        }

    }
}
