using Microsoft.EntityFrameworkCore;
using W1EHUB.Core.Model;
using W1EHUB.Repo.Data;
using W1EHUB.Repo.Repository.Interfaces;
using W1EHUB.Service.Services;

namespace W1EHUB.Repo.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        private readonly RepositoryContext _context;
        public CountryRepository(RepositoryContext context) : base(context)
        {
            _context = context;
        }
    }
}
