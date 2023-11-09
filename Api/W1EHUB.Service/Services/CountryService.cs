using W1EHUB.Core.Model;
using W1EHUB.Repo.Repository.Interfaces;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Service.Services
{
    public class CountryService : GenericService<Country>, ICountryService
    {
        private ICountryRepository _countryRepository;
        public CountryService(IGenericRepository<Country> repo, ICountryRepository countryRepository) : base(repo)
        {
            _countryRepository = countryRepository;
        }

        public async Task<IEnumerable<Country>> GetAllWithRegionAsync()
        {
            return await _countryRepository.FindAll();
        }
    }
}
