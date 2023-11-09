using Microsoft.AspNetCore.Mvc;
using W1EHUB.Core.Dtos;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramService _programService;
        public ProgramController(IProgramService programService)
        {
            _programService = programService;
        }
        [HttpGet]
        public async Task<IActionResult> GET()
        {
            var data = await _programService.GetAllWithCompanyAsync();
            return Ok(data);
        }
        [HttpGet("ByCompanyId/{companyId}")]
        public async Task<IActionResult> GETByCompanyId(int companyId)
        {
            var data = await _programService.FindByCondition(e => e.CompanyId == companyId);
            return Ok(data);
        }

        [HttpPost("Bulk")]
        public async Task<IActionResult> CreateBulkProgramsAsync(Program_Payload[] payload)
        {
            try
            {
                var data = payload.Select(e => new W1EHUB.Core.Model.Program
                {
                    Name = e.Name,
                    Level = e.Level,
                    Activity = e.Activity,
                    ProjectTypes = e.ProjectTypes,
                    Nature = e.Nature,
                    CompanyId = e.CompanyId,
                }).ToArray();

                await _programService.Create(data);
                await _programService.Save();
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
