using W1EHUB.Core.Model;
using W1EHUB.Repo.Repository.Interfaces;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Service.Services
{
    public class FavoriteService : GenericService<Favorite>, IFavoriteService
    {
        public FavoriteService(IGenericRepository<Favorite> repo) : base(repo)
        {
        }
    }
}
