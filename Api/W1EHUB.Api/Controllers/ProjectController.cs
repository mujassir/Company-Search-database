using Microsoft.AspNetCore.Mvc;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GET()
        {
            var projects = await _projectService.GetAllWithCompanyAsync();
            return Ok(projects);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search([FromQuery] String? Country, String? TypeOfCompany, String? Region)
        {
            var projects = await _projectService.SearchWithCompanyAsync(Country, TypeOfCompany, Region);
            return Ok(projects);
        }
    }
}
