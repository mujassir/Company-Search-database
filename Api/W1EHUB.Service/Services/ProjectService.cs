using W1EHUB.Core.Dtos;
using W1EHUB.Core.Model;
using W1EHUB.Repo.Repository.Interfaces;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Service.Services
{
    public class ProjectService : GenericService<Project>, IProjectService
    {
        private IProjectRepository _projectRepository;
        public ProjectService(IGenericRepository<Project> repo, IProjectRepository projectRepository) : base(repo)
        {
            _projectRepository = projectRepository;
        }
        public ProjectService(IGenericRepository<Project> repo) : base(repo)
        {
        }

        public async Task<IEnumerable<ProjectDto>> GetAllWithCompanyAsync()
        {
            var projects = await _projectRepository.GetAllWithCompanyAsync();
            return projects.Select(project => new ProjectDto
            {
                Title = project.Title,
                Nature = project.Nature,
                Type = project.Type,
                Description = project.Description,
                Level = project.Level,
                Year = project.Year,
                CompanyId = project.CompanyId,
                Country = project.Company.Country,
                Region = project.Company.Region,
                Activity = project.Company.TypeOfCompany
            }).ToList();
        }

        public async Task<IEnumerable<ProjectDto>> SearchWithCompanyAsync(string? Country, string? TypeOfCompany, string? Region)
        {
            var projects = await _projectRepository.SearchWithCompanyAsync(Country, TypeOfCompany, Region);
            return projects.Select(project => new ProjectDto
            {
                Title = project.Title,
                Nature = project.Nature,
                Type = project.Type,
                Description = project.Description,
                Level = project.Level,
                Year = project.Year,
                CompanyId = project.CompanyId,
                Country = project.Company.Country,
                Region = project.Company.Region,
                Activity = project.Company.TypeOfCompany
            }).ToList();
        }
    }
}
