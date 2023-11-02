using W1EHUB.Core.Model;

namespace W1EHUB.Service.Interfaces
{
    public interface ICategoryService : IGenericService<Category>
    {
        Task<IEnumerable<Category>> GetAllWithCompanyAsync();
    }
}
