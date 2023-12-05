using Microsoft.AspNetCore.Mvc;
using W1EHUB.Core.Dtos;
using W1EHUB.Core.Model;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IProjectService _projectService;
        public CompanyController(ICompanyService companyService, IProjectService projectService)
        {
            _companyService = companyService;
            _projectService = projectService;

        }

        [HttpGet]
        public async Task<IActionResult> GET()
        {
            var companies = await _companyService.FindAll();
            return Ok(companies);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GETById(int id)
        {
            var company = await _companyService.GetByIdWithStaffMembersAsync(id);
            if(company == null) return NotFound("Company Not Found!");
            return Ok(company);
        }
        [HttpGet("WithPrograms/{id}")]
        public async Task<IActionResult> GETByIdWithProgram(int id)
        {
            var company = await _companyService.GetByIdWithProgramsAsync(id);
            if (company == null) return NotFound("Company Not Found!");
            return Ok(company);
        }
        [HttpGet("LinkedCompaniesBasedOnProject/{id}")]
        public async Task<IActionResult> GETLinkedCompaniesBasedOnProject(int id)
        {
            var projects = await _projectService.FindByCondition(e => e.CompanyId == id);
            if (projects == null) return NotFound("Project Not Found!");

            var projectNames = projects.Select(e => e.Title).ToList();
            var companies = await _companyService.FindByCondition(e => e.Id != id && e.Projects.Any(p => projectNames.Contains(p.Title)));
            if (companies == null) return NotFound("Company Not Found!");
            return Ok(companies);
        }
        [HttpGet("ByCategory/{categoryId}")]
        public async Task<IActionResult> GEByCategory(int categoryId)
        {
            var companies = await _companyService.FindByCondition(e => e.CategoryId == categoryId);
            if (companies == null) return NotFound("Companies Not Found!");
            return Ok(companies);
        }
        [HttpGet("Search")]
        public async Task<IActionResult> SearchCompanyAsync(string? country, string? region, string? categoryId, string? company, string? website)
        {
            var categoryIds = categoryId?.Split(",").Select(int.Parse).ToArray() ?? null;
            var data = await _companyService.SearchCompanyAsync(country?.Split(","), region?.Split(","), categoryIds, company, website);
            return Ok(data);
        }

        [HttpPost("Bulk")]
        public async Task<IActionResult> CreateBulkCompanyAsync(Company_Payload[] payload)
        {
            try
            {
                var data = payload.Select(e => new Company
                {
                    Name = e.Name,
                    Country = e.Country,
                    Region = e.Region,
                    Website = e.Website,
                    Type = e.Type,
                    Description = e.Description,
                    CompanyType = e.CompanyType,
                    OldDetail = e.OldDetail,
                    CategoryId = e.CategoryId,
                }).ToArray();

                await _companyService.Create(data);
                await _companyService.Save();
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("Bulk")]
        public async Task<IActionResult> UpdateBulkCompanyAsync(Company_Payload[] payload)
        {
            try
            {
                var data = payload.Select(e => new Company
                {
                    Id = (int)e.Id,
                    Name = e.Name,
                    Country = e.Country,
                    Region = e.Region,
                    Website = e.Website,
                    Type = e.Type,
                    Description = e.Description,
                    CompanyType = e.CompanyType,
                    OldDetail = e.OldDetail,
                    CategoryId = e.CategoryId,
                }).ToArray();

                await _companyService.Update(data);
                await _companyService.Save();
                return Ok();

            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
