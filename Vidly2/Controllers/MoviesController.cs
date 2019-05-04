using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly2.DTOs;
using Vidly2.Models;

namespace Vidly2.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/Movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        // GET /api/movie/1
        public IHttpActionResult GetMovie(int id)
        {
            var Movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (Movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(Movie));
        }

        // POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto MovieDto) // convention -> PostMovie
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Movie = Mapper.Map<MovieDto, Movie>(MovieDto);

            _context.Movies.Add(Movie);
            _context.SaveChanges();

            MovieDto.Id = Movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + Movie.Id), MovieDto);
        }

        // PUT /api/movies/1
        [HttpPut]
        public void UpdateMovies(int id, MovieDto MovieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var MovieInDB = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (MovieInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<MovieDto, Movie>(MovieDto, MovieInDB);

            //MovieInDB.Name = MovieDto.Name;
            //MovieInDB.Birthdate = MovieDto.Birthdate;
            //MovieInDB.IsSubscribedToNewsletter = MovieDto.IsSubscribedToNewsletter;
            //MovieInDB.MembershipTypeId = MovieDto.MembershipTypeId;

            _context.SaveChanges();
        }

        // DELETE /api/movie/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var MovieInDB = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (MovieInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(MovieInDB);
            _context.SaveChanges();
        }

        // Old version
        //// GET: Movies/Random
        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Shrek!" };

        //    var Movies = new List<Movie>
        //    {
        //        new Movie{Name = "Movie1"},
        //        new Movie{Name = "Movie2"}
        //    };

        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //        Movies = Movies
        //    };

        //    //ViewData["Movie"] = movie;//można ale bez sensu
        //    //ViewBag.Movie = movie;//??

        //    return View(viewModel);
        //    //return Content("Hello World");
        //    //return HttpNotFound();
        //    //return new EmptyResult();
        //    //return RedirectToAction("Index", "Home", new { page =1, sortBy = "name"});
        //}

        //[Route("Movies")]
        //public ActionResult Index()
        //{
        //    var movies = _context.Movies.Include(m => m.Genre);

        //    return View(movies.ToList());
        //}

        //[Route("Movies/Details/{Id}")]
        //public ActionResult Details(int Id)
        //{
        //    var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(c => c.Id == Id);

        //    return View(movie);
        //}

        //[Route("movies/released/{year:regex([0-9]{4}):range(1900,2100)}/{month:regex([0-9]{2}):range(1,12)}")]
        //public ActionResult ByReliseDate(int? year, int month)
        //{
        //    return Content(year + "/" + month);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Save(Movie movie)
        //{
        //    if (movie.Id == 0)
        //    {
        //        movie.DateAdded = DateTime.Today;
        //        _context.Movies.Add(movie);
        //    }
        //    else
        //    {
        //        var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
        //        //TryUpdateModel(movieInDb);//uwaga aktualizuje wszystko co może być niebezpieczne
        //        //TryUpdateModel(movieInDb, "", new string[] { "Name", nameof(movieInDb.GenreID), nameof(movieInDb.NumberInStock), nameof(movieInDb.ReliseDate) });//tylko wymienione don't work ??
        //        movieInDb.GenreID = movie.GenreID;
        //        movieInDb.NumberInStock = movie.NumberInStock;
        //        movieInDb.ReliseDate = movie.ReliseDate;
        //        movieInDb.Name = movie.Name;
        //    }
        //    _context.SaveChanges();

        //    return RedirectToAction("Index", "Movies");
        //}

        //public ActionResult Edit(int id)
        //{
        //    var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

        //    if (movie == null)
        //        return HttpNotFound();

        //    var viewModel = new MovieFormViewModel(movie)
        //    {
        //        Genres = _context.Genres
        //    };

        //    return View("MovieForm", viewModel);
        //}

        //public ActionResult New()
        //{
        //    var genres = _context.Genres.ToList();
        //    var viewModel = new MovieFormViewModel
        //    {
        //        Genres = genres
        //    };

        //    return View("MovieForm", viewModel);
        //}
    }
}