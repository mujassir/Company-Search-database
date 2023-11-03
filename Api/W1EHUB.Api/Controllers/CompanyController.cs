using Microsoft.AspNetCore.Mvc;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> GET()
        {
            var companies = await _companyService.FindAll();
            return Ok(companies);
        }
        [HttpGet("Search")]
        public async Task<IActionResult> SearchCompanyAsync(string? country, string? region, int? categoryId, string? company, string? website)
        {
            var data = await _companyService.SearchCompanyAsync(country, region, categoryId, company, website);
            return Ok(data);
        }
    }
}
