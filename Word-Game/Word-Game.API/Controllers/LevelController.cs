using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Word_Game.Application.Abstractions.IServices;

namespace Word_Game.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly ILevel _levelService;

        public LevelController(ILevel levelService)
        {
            _levelService = levelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(_levelService.GetLevelAsync());
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
