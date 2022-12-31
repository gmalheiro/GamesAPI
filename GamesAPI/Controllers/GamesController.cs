using GamesAPI.Context;
using GamesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GamesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
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

        [HttpGet("{id:int}", Name = "GetGame")]
        //[Route("/ListById/{Id}")]
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

        [HttpPost]
        public ActionResult Post(Game game)
        {
            if (game is null)
                return BadRequest();

            _context.Games.Add(game);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetGame",
                        new { id = game.GameId }, game);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Game game)
        {
            if (id != game.GameId)
            {
                return BadRequest();
            }
            _context.Entry(game).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(game);
        }


        [HttpDelete("{id:int}")]
        public ActionResult<Game> Delete(int id)
        {
            var game = _context.Games.FirstOrDefault(g => g.GameId == id);

            if (game is null)
            {
                return NotFound($"Game {id} was not found");
            }
            _context.Games.Remove(game);
            _context.SaveChanges();
            return Ok(game);
        }

    }
}
