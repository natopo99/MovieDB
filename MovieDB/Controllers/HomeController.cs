using MovieDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private NewMovieContext DBContext { get; set; }

        public HomeController(ILogger<HomeController> logger, NewMovieContext name)
        {
            _logger = logger;
            DBContext = name;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BaconSale()
        {
            return View();
        }

        [HttpGet]

        public IActionResult NewMovies()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewMovies(MovieResponse mr)
        {
            DBContext.Add(mr);
            DBContext.SaveChanges();
            return View("Submitted", mr);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
