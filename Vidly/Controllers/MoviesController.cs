using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity.Validation;
using System.Data.Entity;

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
            var movies = _context.Movies.Include(x => x.Genre).ToList();

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
            var genres = _context.Genres.ToList();
            var movieViewModel = new MovieFormViewModel()
            {
                Genres = genres
            };

            return View("MovieForm", movieViewModel);
        }

        public ActionResult Edit(int id)
        {
            var Movies = _context.Movies.SingleOrDefault(i => i.Id == id);

            if (Movies == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel
            {
                Movies = Movies,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm",viewModel);
        }
        [HttpPost]
        public ActionResult Save(MovieFormViewModel Movie)
        {
            if (Movie.Movies.Id == 0)
            {
                Movie.Movies.DateAdded = DateTime.Now;
                _context.Movies.Add(Movie.Movies);
            }

            else
            {
                var model = _context.Movies.Single(i => i.Id == Movie.Movies.Id);
                model.Name = Movie.Movies.Name;
                model.GenreId = Movie.Movies.GenreId;
                model.DateAdded = DateTime.Now;
                model.NumberInStock = Movie.Movies.NumberInStock;
                model.RealeseDate = Movie.Movies.RealeseDate;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                Console.WriteLine(e);
            }            

            return RedirectToAction("Index","Movies");
        }    
    }
}