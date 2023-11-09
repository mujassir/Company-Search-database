using Microsoft.AspNetCore.Mvc;
using W1EHUB.Core.Dtos;
using W1EHUB.Core.Model;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GET()
        {
            var categories = await _categoryService.FindAll();
            return Ok(categories);
        }
        [HttpPost]
        public async Task<IActionResult> POST(Category_Payload data)
        {
            var favorite = new Category
            {
                Name = data.Name,
            };
            var res = await _categoryService.Create(favorite);
            await _categoryService.Save();
            return Ok(res);
        }
        [HttpPost("Bulk")]
        public async Task<IActionResult> POSTBulk(Category_Payload[] data)
        {
            var categories = data.Select(e => new Category
            {
                Name = e.Name,
            }).ToArray();
            await _categoryService.Create(categories);
            await _categoryService.Save();
            return Ok();
        }
    }
}
