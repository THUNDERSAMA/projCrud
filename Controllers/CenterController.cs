// using projCrud.Models;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using projCrud.Data;

// namespace projCrud.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class CenterController : Controller
//     {
//         private readonly AppDbContext _context;

//         public CenterController(AppDbContext context)
//         {
//             _context = context;
//         }
//         [HttpGet("")]
//         // public IActionResult Index() => View();
//         public async Task<IActionResult> Index()
//         {
//             var centres = await _context.Centres.Include(c => c.Donors).ToListAsync();
//             return View(centres);
//         }
//         // GET: api/Center
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<Center>>> GetCenters()
//         {
//             return await _context.Centres
//                 .Include(c => c.Donors) // include donors in result
//                 .ToListAsync();
//         }

//         // GET: api/Center/2
//         [HttpGet("{id}")]
//         public async Task<ActionResult<Center>> GetCenter(int id)
//         {
//             var Center = await _context.Centres
//                 .Include(c => c.Donors)
//                 .FirstOrDefaultAsync(c => c.Id == id);

//             if (Center == null)
//                 return NotFound();

//             return Center;
//         }

//         // POST: api/Center
//         [HttpPost]
//         public async Task<ActionResult<Center>> CreateCenter(Center Center)
//         {
//             if (!ModelState.IsValid)
//                 return View(Center);
//             _context.Centres.Add(Center);
//             await _context.SaveChangesAsync();

//             return CreatedAtAction(nameof(GetCenter), new { id = Center.Id }, Center);
//         }

//         // PUT: api/Center/3
//         [HttpPut("{id}")]
//         public async Task<IActionResult> UpdateCenter(int id, Center Center)
//         {
//             if (id != Center.Id)
//                 return BadRequest();

//             _context.Entry(Center).State = EntityState.Modified;
//             await _context.SaveChangesAsync();

//             return NoContent();
//         }

//         // DELETE: api/Center/3
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteCenter(int id)
//         {
//             var Center = await _context.Centres.FindAsync(id);
//             if (Center == null)
//                 return NotFound();

//             _context.Centres.Remove(Center);
//             await _context.SaveChangesAsync();

//             return NoContent();
//         }
//     }
// }
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projCrud.Data;
using projCrud.Models;

namespace projCrud.Controllers
{
    public class CenterController : Controller
    {
        private readonly AppDbContext _context;

        public CenterController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var centers = await _context.Center.Include(c => c.Donors).ToListAsync();
            return View(centers); // Renders Views/Center/Index.cshtml
        }

        public IActionResult Create() => View();
        public IActionResult Edit() => View();
        [HttpPost]
        public async Task<IActionResult> Create(Center center)
        {
            Console.WriteLine("added");
            // if (!ModelState.IsValid)
            //     return View(center);
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine("Validation Error: " + error.ErrorMessage);
                }
                return View(center);
            }
            _context.Center.Add(center);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Center added successfully!";

            return RedirectToAction(nameof(Index));
        }


        // Add Edit/Delete as needed here too
    }
}
