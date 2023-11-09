using W1EHUB.Core.Dtos;
using W1EHUB.Core.Model;
using W1EHUB.Repo.Repository;
using W1EHUB.Repo.Repository.Interfaces;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Service.Services
{
    public class ProjectService : GenericService<Project>, IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository repo) : base(repo)
        {
            _projectRepository = repo;
        }

        public async Task<IEnumerable<CompanyProjectDto>> GetAllWithCompanyAsync()
        {
            var data = await _projectRepository.GetAllWithCompanyAsync();
            return data.Select(p => new CompanyProjectDto
            {
                Title = p.Title,
                Genre = p.Genre,
                Year = p.Year,
                ImagePath = p.ImagePath,
                Certificate = p.Certificate,
                RunTime = p.RunTime,
                Rating = p.Rating,
                Votes = p.Votes,
                CompanyId = p.CompanyId,
                Company = new CompanyDto
                {
                    Id = p.Company.Id,
                    Name = p.Company.Name,
                    Country = p.Company.Country,
                    Type = p.Company.Type,
                    Website = p.Company.Website,
                    CategoryId = p.Company.CategoryId,
                }
            }).ToList();
        }
    }
}
