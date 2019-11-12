using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();
            return View(movies);
        }

        // GET: Movies/Random
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult New()
        {

            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieFromDB = _context.Movies.Single(m => m.Id == movie.Id);
                movieFromDB.Name = movie.Name;
                movieFromDB.NumberInStock = movie.NumberInStock;
                /*movieFromDB.ReleaseDate = new System.DateTime(movie.ReleaseDate.Value.Year,movie.ReleaseDate.Value.Month,movie.ReleaseDate.Value.Day);*/
                movieFromDB.ReleaseDate = movie.ReleaseDate;
                movieFromDB.AddedDate = DateTime.Now;
                movieFromDB.GenreId = movie.GenreId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");

        }

        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == Id);
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

    }
}