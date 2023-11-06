using Microsoft.AspNetCore.Mvc;
using W1EHUB.Core.Dtos;

namespace W1EHUB.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {

        [HttpPost]
        public IActionResult LogInUser(LogInUser_Payload User)
        {
            if (!(User.Email == "abc@email.com" && User.Password == "abc"))
                return BadRequest("Invalid User!");

            LogInUser_Response responseData = new ()
            {
                UserId = 1,
                Email = User.Email,
                AccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c",
                AccessTokenExpiry = 30
            };
            return Ok(responseData);
        }
    }
}
