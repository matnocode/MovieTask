using Microsoft.AspNetCore.Mvc;
using MovieTask.Data;
using MovieTask.Models;
using System.Diagnostics;

namespace MovieTask.Controllers
{
    
    public class HomeController : Controller
    {
        public HomeController(MovieDbContext context)
        {
            _context = context;
        }
        readonly MovieDbContext _context;
        public IActionResult Index()
        {
            return View(_context.movies.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}