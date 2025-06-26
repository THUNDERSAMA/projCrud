using projCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projCrud.Data;

namespace projCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonorApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DonorApiController(AppDbContext context)
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

            return Ok(donor);
        }

        // POST: api/donor
        [HttpPost]
        public async Task<ActionResult<Donor>> CreateDonor([FromBody, Bind("Name,Age,BloodGroup,DonationDate,CenterId")] Donor donor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Donors.Add(donor);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Donor added successfully" });
        }

        // PUT: api/donor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDonor(int id, [FromBody] Donor updatedDonor)
        {

            var existing = await _context.Donors.FindAsync(id);
            if (existing == null)
                return NotFound();

            existing.Name = updatedDonor.Name;
            existing.Age = updatedDonor.Age;
            existing.BloodGroup = updatedDonor.BloodGroup;
            existing.DonationDate = updatedDonor.DonationDate;
            existing.CenterId = updatedDonor.CenterId;


            await _context.SaveChangesAsync();
            return Ok(new { message = "Donor updated successfully." });
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

            return Ok(new { message = "Donor deleted successfully." });
        }
    }
}