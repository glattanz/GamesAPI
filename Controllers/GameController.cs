using Microsoft.AspNetCore.Mvc;

namespace GamesAPI.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpGet, Route("")]
        public IActionResult Test()
        {
            return Ok("Working...");
        }
    }
}