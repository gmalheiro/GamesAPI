using GamesAPI.Context;
using GamesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GameController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/ListAll")]
        public ActionResult<IEnumerable<Game>> Get()
        {
            try
            {
                return _context.Games.AsNoTracking().ToList();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "There was an error processing your request...");
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<Game> Get (int id)
        {
            try
            {
                var game = _context.Games.FirstOrDefault(g => g.GameId == id);
                if (game is null)
                {
                    return NotFound($"Game {id} was not found");
                }
                return Ok(game);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
