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

        if(User.IsInRole(RoleName.CanManageMovies))
            return View("List");
        return View("ReadOnlyList");
        } 
        
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
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

            var viewModel = new MovieFormViewModel(Movies)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie Movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(Movie)
                {
                    Genres = _context.Genres.ToList()    
                };
                return View("MovieForm",viewModel);
            }

            if (Movie.Id == 0)
            {
                Movie.DateAdded = DateTime.Now;
                _context.Movies.Add(Movie);
            }

            else
            {
                var model = _context.Movies.Single(i => i.Id == Movie.Id);
                model.Name = Movie.Name;
                model.GenreId = Movie.GenreId;
                model.NumberInStock = Movie.NumberInStock;
                model.ReleaseDate = Movie.ReleaseDate;
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