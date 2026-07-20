using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimSetupManager.Api.Data;
using SimSetupManager.Core.Entities;

namespace SimSetupManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TracksController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Track>>> GetTracks() => await _context.Tracks.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Track>> CreateTrack([FromBody] Track newTrack)
        {
            _context.Tracks.Add(newTrack);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTracks), new { id = newTrack.Id }, newTrack);
        }
    }
}