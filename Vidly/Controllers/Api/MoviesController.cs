using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        /// <summary>
        /// Get All Movies
        /// </summary>
        /// <endpoint>
        /// GET /api/movies
        /// </endpoint>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult getMovies()
        {
            return Ok(_context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>));
        }

        /// <summary>
        /// Get Single Movie
        /// </summary>
        /// <endpoint>
        /// GET /api/movies/{id}
        /// </endpoint>
        /// <params>id</params>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult getMovies(int id)
        {
            Movie oMovie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (oMovie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(oMovie));
        }

        /// <summary>
        /// Create New Movie
        /// </summary>
        /// <endpoint>
        /// POST /api/movies
        /// </endpoint>
        /// <params>MovieDto</params>
        /// <returns>IHttpActionResult</returns>
        [HttpPost]
        public IHttpActionResult createMovie(MovieDto movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDTO);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDTO.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);
        }

        /// <summary>
        /// Update Existing Movie
        /// </summary>
        /// <endpoint>
        /// PUT /api/movies/{id}
        /// </endpoint>
        /// <params>id</params>
        /// <params>IHttpActionResult</params>
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Movie oMovie = _context.Movies.FirstOrDefault(c => c.Id == id);
            if (oMovie == null)
                return NotFound();

            Mapper.Map(movieDto, oMovie);

            _context.SaveChanges();

            return Ok();
        }

        /// <summary>
        /// Delete Movie
        /// </summary>
        /// <endpoint>
        /// DELETE /api/movies/{id}
        /// </endpoint>
        /// <params>id</params>
        /// <params>IHttpActionResult</params>
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            Movie oMovie = _context.Movies.FirstOrDefault(c => c.Id == id);
            if (oMovie == null)
                return NotFound();

            _context.Movies.Remove(oMovie);
            _context.SaveChanges();
            return Ok();
        }

    }
}
