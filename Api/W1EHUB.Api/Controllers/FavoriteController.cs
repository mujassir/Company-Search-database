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
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;
        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpGet]
        public async Task<IActionResult> GET(int userId)
        {
            var data = await _favoriteService.FindByCondition(e => e.UserId == userId);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> POST(Favorite_Payload data)
        {
            var favorite = new Favorite
            {
                Title = data.Title,
                UserId = data.UserId,
                CreateAt = DateTime.Now,
            };
            var res = await _favoriteService.Create(favorite);
            await _favoriteService.Save();
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var favorite = await _favoriteService.Find(id);
            if (favorite == null) return NotFound();
            await _favoriteService.Delete(favorite);
            await _favoriteService.Save();
            return Ok();
        }
    }
}
