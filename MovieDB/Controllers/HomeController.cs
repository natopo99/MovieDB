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
        // we pas in the movie ID so the program knows which movie to edit
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

        // Both the edit and delete models need a get and post request
        [HttpGet]
        public IActionResult Trash(int movieid)
        {
            var movie = DBContext.responses.Single(x => x.MovieId == movieid);

            return View(movie);
        }

        
        // we pass in the movie response so the program can have access to the data 
        [HttpPost]
        public IActionResult Trash(MovieResponse mr) //needed to change it to trash instead of delete
        {
            DBContext.responses.Remove(mr);
            DBContext.SaveChanges();

            return RedirectToAction("MovieCollection");
        }

    }
}
