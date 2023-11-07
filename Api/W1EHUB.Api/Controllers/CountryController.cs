using Microsoft.AspNetCore.Mvc;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GET()
        {
            var data = await _countryService.GetAllWithRegionAsync();
            return Ok(data);
        }
    }
}
