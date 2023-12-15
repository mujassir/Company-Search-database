using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using W1EHUB.Core.Dtos;
using W1EHUB.Core.Model;
using W1EHUB.Service.Interfaces;

namespace W1EHUB.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FavoriteCompanyController : ControllerBase
    {
        private readonly IFavoriteCompanyService _favoriteService;
        public FavoriteCompanyController(IFavoriteCompanyService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpGet]
        public async Task<IActionResult> GET(int userId, int companyId)
        {
            var data = await _favoriteService.GetFavoriteCompaniesByIdAsync(userId, companyId);
            return Ok(data);
        }
        [HttpGet("CompanyByFavoriteId")]
        public async Task<IActionResult> GetCompanyByFavoriteId(int favoriteId)
        {
            var data = await _favoriteService.GetCompaniesByFavoriteIdAsync(favoriteId);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> POST(FavoriteCompany_Payload data)
        {
            var favorite = new FavoriteCompany
            {
                FavoriteId = data.FavoriteId,
                CompanyId = data.CompanyId,
                CreateAt = DateTime.Now,
            };
            var res = await _favoriteService.Create(favorite);
            await _favoriteService.Save();
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int favoriteId, int companyId)
        {
            var favorites = await _favoriteService.FindByCondition(e => e.FavoriteId == favoriteId && e.CompanyId == companyId);
            if (!favorites.Any()) return NotFound();
            var favorite = favorites.FirstOrDefault();
            await _favoriteService.Delete(favorite);
            await _favoriteService.Save();
            return Ok();
        }
    }
}
