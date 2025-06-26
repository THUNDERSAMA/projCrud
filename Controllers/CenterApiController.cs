using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projCrud.Models;
using projCrud.Data;

namespace projCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CenterApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CenterApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Center>>> GetCenters()
        {
            return await _context.Center.Include(c => c.Donors).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Center>> GetCenter(int id)
        {
            var center = await _context.Center.Include(c => c.Donors).FirstOrDefaultAsync(c => c.Id == id);
            if (center == null)
                return NotFound();
            return Ok(center);
        }

        [HttpPost]
        public async Task<ActionResult<Center>> CreateCenter(Center center)
        {
            _context.Center.Add(center);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Center added successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCenter(int id, [FromBody] Center updatedCenter)
        {
            var existing = await _context.Center.FindAsync(id);
            if (existing == null)
                return NotFound();

            existing.Name = updatedCenter.Name;
            existing.Location = updatedCenter.Location;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Center updated successfully." });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCenter(int id)
        {
            var center = await _context.Center.FindAsync(id);
            if (center == null)
                return NotFound();

            _context.Center.Remove(center);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Center deleted successfully." });
        }
    }
}
