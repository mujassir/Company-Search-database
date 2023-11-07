using W1EHUB.Core.Model;
using W1EHUB.Repo.Data;
using W1EHUB.Repo.Repository.Interfaces;
using W1EHUB.Service.Services;

namespace W1EHUB.Repo.Repository
{
    public class RegionRepository : GenericRepository<Region>, IRegionRepository
    {
        public RegionRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
