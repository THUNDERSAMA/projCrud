using projCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projCrud.Data;

namespace projCrud.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Will render Views/Home/Index.cshtml
            return View();
        }
    }
}