using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projCrud.Data;
using projCrud.Models;

namespace projCrud.Controllers
{
    public class DonorController : Controller
    {
        private readonly AppDbContext _context;

        public DonorController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var donors = await _context.Donors
                .Include(d => d.Center)
                .ToListAsync();
            return View(donors); // Renders Views/Center/Index.cshtml
        }

        public async Task<IActionResult> Create()
        {
            var centers = await _context.Center.ToListAsync();
            return View(centers); // This will be passed to the dropdown
        }
        public async Task<IActionResult> EditAsync()
        {
            var centers = await _context.Center.ToListAsync();
            return View(centers);
        }


        // Add Edit/Delete as needed here too
    }
}