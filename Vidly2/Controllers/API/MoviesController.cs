using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly2.DTOs;
using Vidly2.Models;
using System.Data.Entity;

namespace Vidly2.Controllers.API
{
    [Authorize(Roles = RoleName.CanManageMovies)]
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
            return _context.Movies.Include(m => m.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>);
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
    }
}
