using Microsoft.AspNetCore.Mvc;
using W1EHUB.Api.Common;
using W1EHUB.Core.Model;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DataUploadController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ICompanyService _companyService;
        private readonly IStaffMemberService _staffMemeberService;
        public DataUploadController(ICategoryService categoryService, ICompanyService companyService, IStaffMemberService staffMemeberService)
        {
            _categoryService = categoryService;
            _companyService = companyService;
            _staffMemeberService = staffMemeberService;

        }
        [HttpGet]
        public IActionResult GET()
        {
            try
            {
                var data = DataBuilderFromFile.ExtractFromFile();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("Categories")]
        public async Task<IActionResult> GetCategoriesFromFile()
        {
            try
            {
                var fileData = DataBuilderFromFile.ExtractFromFile();
                var categories = DataBuilderFromFile.ExtractAndRemoveDuplicates(fileData, "Category");
                return Ok(categories.Select(e => e["Category"]));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost("Categories")]
        public async Task<IActionResult> UploadCategoriesFromFile()
        {
            try
            {
                var fileData = DataBuilderFromFile.ExtractFromFile();
                var categories = DataBuilderFromFile.ExtractAndRemoveDuplicates(fileData, "Category");
                var categoryEntities = categories.Select(e => new Category { Name = e["Category"], CreateAt = DateTime.Now }).ToArray();
                
                await _categoryService.Create(categoryEntities);
                await _categoryService.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Companies")]
        public async Task<IActionResult> GetCompaniesFromFile()
        {
            try
            {
                var categories = await _categoryService.FindAll();
                
                var fileData = DataBuilderFromFile.ExtractFromFile();
                var companies = DataBuilderFromFile.ExtractAndRemoveDuplicates(fileData, "PRODUCTION COMPANY");
                var companyEntities = companies.Select(e =>
                    new Company
                    {
                        Name = string.IsNullOrEmpty(e["COMPANY"]) ? e["PRODUCTION COMPANY"] : e["COMPANY"],
                        Website = e.TryGetValue("WEBSITE", out var website) ? website : null,
                        Type = e.TryGetValue("TYPE", out var type) ? type : null,
                        Country = e.TryGetValue("COUNTRY OF ORIGIN/ REGION", out var country) ? country : null,
                        OldDetail = e["PRODUCTION COMPANY"],
                        CategoryId = (int)categories.FirstOrDefault(c => c.Name == e["Category"]).Id,
                        CreateAt = DateTime.Now
                    }
                ).ToArray();
                
                return Ok(companyEntities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Companies")]
        public async Task<IActionResult> UploadCompaniesFromFile()
        {
            try
            {
                var categories = await _categoryService.FindAll();

                var fileData = DataBuilderFromFile.ExtractFromFile();
                var companies = DataBuilderFromFile.ExtractAndRemoveDuplicates(fileData, "PRODUCTION COMPANY");
                var companyEntities = companies.Select(e =>
                    new Company
                    {
                        Name = string.IsNullOrEmpty(e["COMPANY"]) ? e["PRODUCTION COMPANY"] : e["COMPANY"],
                        Website = e.TryGetValue("WEBSITE", out var website) ? website : null,
                        Type = e.TryGetValue("TYPE", out var type) ? type : null,
                        Country = e.TryGetValue("COUNTRY OF ORIGIN/ REGION", out var country) ? country : null,
                        OldDetail = e["PRODUCTION COMPANY"],
                        CategoryId = (int)categories.FirstOrDefault(c => c.Name == e["Category"]).Id,
                        CreateAt = DateTime.Now
                    }
                ).ToArray();
                await _companyService.Create(companyEntities);
                await _companyService.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Staff")]
        public async Task<IActionResult> GetStaffFromFile()
        {
            try
            {
                var companies = await _companyService.FindAll();

                var fileData = DataBuilderFromFile.ExtractFromFile();

                var staffMemberEntities = fileData.Select(e =>
                {
                    var name = e.TryGetValue("NAMES OF HEAD STAFF", out var nameValue) ? nameValue : null;
                    var email = e.TryGetValue("EMAILS", out var emailValue) ? emailValue : null;
                    var role = e.TryGetValue("ROLE", out var roleValue) ? roleValue : null;

                    string companyName = string.IsNullOrEmpty(e["COMPANY"]) ? e["PRODUCTION COMPANY"] : e["COMPANY"];

                    var company = companies.FirstOrDefault(c => c.Name == companyName);
                    int companyId = company != null ? company.Id : 0; // Set your desired default value.

                    return new StaffMember
                    {
                        Name = name,
                        Email = email,
                        Role = role,
                        CompanyId = companyId,
                        CreateAt = DateTime.Now
                    };
                }).ToArray();

                return Ok(staffMemberEntities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Staff")]
        public async Task<IActionResult> UploadStaffFromFile()
        {
            try
            {
                var companies = await _companyService.FindAll();

                var fileData = DataBuilderFromFile.ExtractFromFile();

                var staffMemberEntities = fileData.Select(e =>
                {
                    var name = e.TryGetValue("NAMES OF HEAD STAFF", out var nameValue) ? nameValue : null;
                    var email = e.TryGetValue("EMAILS", out var emailValue) ? emailValue : null;
                    var role = e.TryGetValue("ROLE", out var roleValue) ? roleValue : null;

                    var company = companies.FirstOrDefault(c => c.OldDetail == e["PRODUCTION COMPANY"]);

                    int companyId;

                    if (company == null)
                    {
                        companyId = 0;
                    }

                    companyId = company.Id;

                    return new StaffMember
                    {
                        Name = name,
                        Email = email,
                        Role = role,
                        CompanyId = companyId,
                        CreateAt = DateTime.Now
                    };
                }).ToArray();

                await _staffMemeberService.Create(staffMemberEntities);
                await _staffMemeberService.Save();
                return Ok(fileData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
