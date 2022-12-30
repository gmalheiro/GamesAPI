using GamesAPI.Context;
using GamesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GenreController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Genre>> Get()
        {
            try
            {
                return _context.Genres.AsNoTracking().ToList();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "There was an error processing your request...");
            }
        }

        [HttpGet("{id:int}")]
        //[Route("/ListById/{Id}")]
        public ActionResult<Genre> Get(int id)
        {
            try
            {
                var genre = _context.Genres.FirstOrDefault(g => g.GenreId == id);
                if (genre is null)
                {
                    return NotFound($"Genre {id} was not found");
                }
                return Ok(genre);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("/CreateGenre")]
        public ActionResult Post(Genre genre)
        {
            if (genre is null)
                return BadRequest("Genre is null");

            _context.Add(genre);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetGenre",
                new { id = genre.GenreId }, genre);
        }

        [HttpPut]
        public ActionResult Put(int id, Genre genre)
        {
            if (id != genre.GenreId)
            {
                return BadRequest();
            }
            _context.Entry(genre).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(genre);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Genre> Delete(int id)
        {
            var genre = _context.Genres.FirstOrDefault(g => g.GenreId== id);

            if (genre is null)
            {
                return NotFound();
            }
            _context.Genres.Remove(genre);
            _context.SaveChanges();
            return Ok(genre);
        }

    }
}
