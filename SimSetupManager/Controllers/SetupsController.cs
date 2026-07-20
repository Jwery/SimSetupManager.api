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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Setup>>> GetSetups()
        {
            return await _context.Setups.ToListAsync();
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
            return CreatedAtAction(nameof(GetSetups), new { id = newSetup.Id }, newSetup);
        }
    }
}