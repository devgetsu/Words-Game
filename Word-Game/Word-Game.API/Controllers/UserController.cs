using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Word_Game.Application.Abstractions.IServices;
using Word_Game.Domain.DataTransferObjects;

namespace Word_Game.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(UserDTO user)
        {
            try
            {
                return Ok(await _userService.CreateAsync(user));
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _userService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> GetAll(Guid id, UserDTO userDTO)
        {
            try
            {
                return Ok(await _userService.UpdateAsync(userDTO, id));
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }

    }
}
