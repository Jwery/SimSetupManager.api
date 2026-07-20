using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimSetupManager.Api.Data;
using SimSetupManager.Core.Entities;

namespace SimSetupManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VehiclesController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles() => await _context.Vehicles.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Vehicle>> CreateVehicle([FromBody] Vehicle newVehicle)
        {
            _context.Vehicles.Add(newVehicle);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVehicles), new { id = newVehicle.Id }, newVehicle);
        }
    }
}