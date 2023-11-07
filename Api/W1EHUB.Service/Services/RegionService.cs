using W1EHUB.Core.Model;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Service.Services
{
    public class RegionService : GenericService<Region>, IRegionService
    {
        public RegionService(IGenericRepository<Region> repo) : base(repo)
        {
        }
    }
}
