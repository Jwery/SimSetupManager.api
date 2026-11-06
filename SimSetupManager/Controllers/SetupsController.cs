using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimSetupManager.Api.Data;
using SimSetupManager.Core.Entities;

namespace SimSetupManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetupsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SetupsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/setups
        // Récupère la liste de tous les setups
        // GET: api/setups/5
        // 1. Récupérer TOUS les setups (C'est celle-ci qui te manque ou qui est mal annotée)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Setup>>> GetSetups()
        {
            return await _context.Setups.ToListAsync();
        }

        // 2. Récupérer UN SEUL setup précis
        [HttpGet("{id}")]
        public async Task<ActionResult<Setup>> GetSetup(Guid id)
        {
            var setup = await _context.Setups.FindAsync(id);
            if (setup == null) return NotFound();
            return setup;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSetup(Guid id, [FromBody] Setup updatedSetup)
        {
            if (id != updatedSetup.Id) return BadRequest("L'ID ne correspond pas.");

            _context.Entry(updatedSetup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Setups.Any(e => e.Id == id)) return NotFound();
                else throw;
            }

            return NoContent(); // Code 204 : Succès, mais rien à renvoyer
        } 

        // POST: api/setups
        // Crée un nouveau setup dans la base de données
        [HttpPost]
        public async Task<ActionResult<Setup>> CreateSetup([FromBody] Setup newSetup)
        {
            // L'ID, la date de création et les Guid vides seront gérés automatiquement ou par l'objet
            _context.Setups.Add(newSetup);
            await _context.SaveChangesAsync();

            // Retourne un code HTTP 201 (Created) avec l'objet tel qu'il a été enregistré
            return CreatedAtAction(nameof(GetSetup), new { id = newSetup.Id }, newSetup);
        }
    }
}