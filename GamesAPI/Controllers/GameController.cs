﻿using GamesAPI.Context;
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
            {
                return BadRequest("Game is null");
            }
            _context.Add(game);
            _context.SaveChanges();

            return Ok(game);
        }

        [HttpPut]
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
                return NotFound();
            }
            _context.Games.Remove(game);
            _context.SaveChanges();
            return Ok(game);
        }

    }
}
