using projCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projCrud.Data;

namespace projCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DonorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/donor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donor>>> GetDonors()
        {
            return await _context.Donors
                .Include(d => d.Center)
                .ToListAsync();
        }

        // GET: api/donor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Donor>> GetDonor(int id)
        {
            var donor = await _context.Donors
                .Include(d => d.Center)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (donor == null)
                return NotFound();

            return donor;
        }

        // POST: api/donor
        [HttpPost]
        public async Task<ActionResult<Donor>> CreateDonor(Donor donor)
        {
            _context.Donors.Add(donor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDonor), new { id = donor.Id }, donor);
        }

        // PUT: api/donor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDonor(int id, Donor donor)
        {
            if (id != donor.Id)
                return BadRequest();

            _context.Entry(donor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/donor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonor(int id)
        {
            var donor = await _context.Donors.FindAsync(id);
            if (donor == null)
                return NotFound();

            _context.Donors.Remove(donor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}