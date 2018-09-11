using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var movies = _context.Movies.ToList();

            return View(movies);
        } 
        
        public ActionResult Details(int id)
        {
            var movies = _context.Movies.SingleOrDefault(i => i.Id == id);

            if (movies == null)
            {
                return HttpNotFound();
            }
            return View(movies);
        }

        public ActionResult New()
        {
            var movie = _context.Movies.ToList();

            return View("MovieForm",movie);
        }

        public ActionResult Edit(int id)
        {
            var model = _context.Movies.SingleOrDefault(i => i.Id == id);

            if (model== null)
            {
                return HttpNotFound();
            }

            return View("MovieForm",model);
        }
        [HttpPost]
        public ActionResult Save(Movie Movie)
        {
            if (Movie.Id == 0)
            {
                Movie.DateAdded = DateTime.Now;
                _context.Movies.Add(Movie);
            }

            else
            {
                var model = _context.Movies.Single(i => i.Id == Movie.Id);
                model.Name = Movie.Name;
                model.Genre = Movie.Genre;
                model.DateAdded = DateTime.Now;
                model.NumberInStock = Movie.NumberInStock;
                model.RealeseDate = Movie.RealeseDate;

            }
            _context.SaveChanges();

            return RedirectToAction("Index","Movies");
        }    
    }
}