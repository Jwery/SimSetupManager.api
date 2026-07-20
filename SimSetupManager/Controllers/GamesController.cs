using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimSetupManager.Api.Data;
using SimSetupManager.Core.Entities;

namespace SimSetupManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GamesController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames() => await _context.Games.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Game>> CreateGame([FromBody] Game newGame)
        {
            _context.Games.Add(newGame);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGames), new { id = newGame.Id }, newGame);
        }
    }
}