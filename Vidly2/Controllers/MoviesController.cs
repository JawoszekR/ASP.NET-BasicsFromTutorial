using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        [Route("Movies")]
        public ActionResult Index()
        {
            //var movies = _context.Movies.Include(m => m.Genre);

            //return View(movies.ToList());
            return View();
        }

        [Route("Movies/Details/{Id}")]
        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(c => c.Id == Id);

            return View(movie);
        }

        [Route("movies/released/{year:regex([0-9]{4}):range(1900,2100)}/{month:regex([0-9]{2}):range(1,12)}")]
        public ActionResult ByReliseDate(int? year, int month)
        {
            return Content(year + "/" + month);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Today;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                //TryUpdateModel(movieInDb);//uwaga aktualizuje wszystko co może być niebezpieczne
                //TryUpdateModel(movieInDb, "", new string[] { "Name", nameof(movieInDb.GenreID), nameof(movieInDb.NumberInStock), nameof(movieInDb.ReliseDate) });//tylko wymienione don't work ??
                movieInDb.GenreID = movie.GenreID;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReliseDate = movie.ReliseDate;
                movieInDb.Name = movie.Name;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }
    }
}