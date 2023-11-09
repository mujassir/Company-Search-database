using W1EHUB.Core.Dtos;
using W1EHUB.Core.Model;
using W1EHUB.Repo.Repository;
using W1EHUB.Repo.Repository.Interfaces;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Service.Services
{
    public class ProgramService : GenericService<Program>, IProgramService
    {
        private readonly IProgramRepository _programRepository;
        public ProgramService(IProgramRepository repo) : base(repo)
        {
            _programRepository = repo;
        }

        public async Task<IEnumerable<CompanyProgramDto>> GetAllWithCompanyAsync()
        {
            var data = await _programRepository.GetAllWithCompanyAsync();
            return data.Select(program => new CompanyProgramDto
            {
                Id = program.Id,
                Name = program.Name,
                Level = program.Level,
                Activity = program.Activity,
                ProjectTypes = program.ProjectTypes,
                Nature = program.Nature,
                CompanyId = program.CompanyId,
                Company = new CompanyDto
                {
                    Name = program.Company.Name,
                    Country = program.Company.Country,
                    Type = program.Company.Type,
                    Website = program.Company.Website,
                    CategoryId = program.Company.CategoryId,
                }
            }).ToList();
        }
    }
}
