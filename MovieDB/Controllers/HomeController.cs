using MovieDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MovieDB.Controllers
{
    public class HomeController : Controller
    {

        private NewMovieContext DBContext { get; set; }

        public HomeController(NewMovieContext name)
        {

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
            ViewBag.Categories = DBContext.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult NewMovies(MovieResponse mr)
        {
            if (ModelState.IsValid)
            {
                DBContext.Add(mr);
                DBContext.SaveChanges();
                return View("Submitted", mr);
            }
            else
            {
                ViewBag.Categories = DBContext.Categories.ToList();
                return View(mr);
            }
        }

        public IActionResult MovieCollection()
        {
             var responses = DBContext.responses
                .Include(x => x.Category)
                .ToList();

            return View(responses);
        }
        [HttpGet]

        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = DBContext.Categories.ToList();

            var movie = DBContext.responses.Single(x => x.MovieId == movieid);

            return View("NewMovies", movie);
        }
        [HttpPost]
        public IActionResult Edit(MovieResponse mr)
        {
            DBContext.Update(mr);
            DBContext.SaveChanges();

            return RedirectToAction("MovieCollection");
        }


        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = DBContext.responses.Single(x => x.MovieId == movieid);

            return View(movie);
        }

        
        
        [HttpPost]
        public IActionResult Delete(MovieResponse mr)
        {
            DBContext.responses.Remove(mr);
            DBContext.SaveChanges();

            return RedirectToAction("MovieCollection");
        }

    }
}
