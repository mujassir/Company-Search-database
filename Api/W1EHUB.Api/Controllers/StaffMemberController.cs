using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StaffMemberController : ControllerBase
    {
        private readonly IStaffMemberService _staffService;
        public StaffMemberController(IStaffMemberService staffMemberService)
        {
            _staffService = staffMemberService;
        }
        [HttpGet]
        public async Task<IActionResult> GET()
        {
            var data = await _staffService.GetAllWithCompanyAsync();
            return Ok(data);
        }
        [HttpGet("Search")]
        public async Task<IActionResult> SearchAllWithCompanyAsync(string? role, string? country, string? company, string? website, int? categoryId)
        {
            var data = await _staffService.SearchAllWithCompanyAsync(role, country, company, website, categoryId);
            return Ok(data);
        }
    }
}
