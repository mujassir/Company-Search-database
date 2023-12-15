using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using W1EHUB.Core.Dtos;
using W1EHUB.Core.Model;
using W1EHUB.Repo.Data;
using W1EHUB.Repo.Repository.Interfaces;
using W1EHUB.Service.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace W1EHUB.Repo.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        private readonly RepositoryContext _context;
        public CountryRepository(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CountryDto>> GetAllWithCountryCountAsync()
        {
            var query = from country in _context.Countries
                        join company in _context.Companies
                            on country.Name equals company.Country into companyGroup
                        from company in companyGroup.DefaultIfEmpty()
                        group new { country, company } by new
                        {
                            country.Id,
                            country.Name,
                            country.CreateAt
                        } into grouped
                        select new CountryDto
                        {
                            Id = grouped.Key.Id,
                            Name = grouped.Key.Name,
                            NumberOfCompanies = grouped.Count(c => c.company != null).ToString(),
                            CreateAt = grouped.Key.CreateAt
                        };

            var countryDtos = await query.ToListAsync();

            return countryDtos;
        }
    }
}
