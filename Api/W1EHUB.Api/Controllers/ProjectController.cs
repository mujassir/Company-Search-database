using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using W1EHUB.Core.Dtos;
using W1EHUB.Core.Model;
using W1EHUB.Service.Interfaces;
using W1EHUB.Service.Services;

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
            var data = await _projectService.GetAllWithCompanyAsync();
            return Ok(data);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Project_Payload payload)
        {
            var project = new Project
            {
                Title = payload.Title,
                Genre = payload.Genre,
                Year = payload.Year,
                ImagePath = payload.ImagePath,
                Certificate = payload.Certificate,
                RunTime = payload.RunTime,
                Rating = payload.Rating,
                Votes = payload.Votes,
                CompanyId = payload.CompanyId,
            };

            var data = await _projectService.Create(project);
            await _projectService.Save();
            return Ok(data);
        }
        
        [HttpPost("bulk")]
        public async Task<IActionResult> CreateBulk(Project_Payload[] payload)
        {
            try
            {
                Project[] project = payload.Select(p => new Project
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
                }).ToArray();
                await _projectService.Create(project);
                await _projectService.Save();
                return Ok();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
