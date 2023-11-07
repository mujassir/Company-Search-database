using W1EHUB.Core.Model;

namespace W1EHUB.Service.Interfaces
{
    public interface ICountryService: IGenericService<Country>
    {
        Task<IEnumerable<Country>> GetAllWithRegionAsync();
    }
}
