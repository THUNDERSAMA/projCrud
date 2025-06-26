using projCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projCrud.Data;

namespace projCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new DashboardViewModel
            {
                TotalDonors = _context.Donors.Count(),
                TotalCenters = _context.Center.Count(),
                TotalDonations = _context.Donors.Count(),
                DonationsThisMonth = _context.Donors
                    .Count(d => d.DonationDate.Month == DateTime.Now.Month &&
                                d.DonationDate.Year == DateTime.Now.Year)
            };

            return View(model);
        }
    }
}