using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Word_Game.Application.Abstractions.IServices;
using Word_Game.Domain.DataTransferObjects;

namespace Word_Game.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly IWordService _wordService;
        public WordController(IWordService wordService)
        {
            _wordService = wordService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(WordDTO wordDTO)
        {
            try
            {
                return Ok(await _wordService.CreateAsync(wordDTO));
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                return Ok(await _wordService.GetAllAsync());
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                return Ok(await _wordService.GetByIdAsync(id));
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                return Ok(await _wordService.DeleteAsync(id));
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id, WordDTO wordDTO)
        {
            try
            {
                return Ok(await _wordService.UpdateAsync(id, wordDTO));
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
