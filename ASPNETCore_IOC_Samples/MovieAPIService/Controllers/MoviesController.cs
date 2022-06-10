using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPIService.Data;
using MovieAPIService.DTO;
using MovieAPIService.Models;
using MovieAPIService.DTO.Mapper;

namespace MovieAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public MoviesController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public IEnumerable<MovieDTO> GetMovies()
        {
            IList<Movie> movies = _context.Movies.Include(c=>c.MovieComments).ToList();

            return movies.MoviesToDTOsWithRelation();
        }

        // GET: api/Movies
        [HttpGet("GetMoviesWithEasyPaging")]
        public IEnumerable<MovieDTO> GetMovies(int pageIndex, int pageSize, string search)
        {
            IList<Movie> movies = _context.Movies.Include(c => c.MovieComments)
                                                 .Where(m=>m.Title.Contains(search) || m.Description.Contains(search))
                                                 .Skip((pageIndex-1)*pageSize).Take(pageSize)
                                                 .ToList();

            return movies.MoviesToDTOsWithRelation();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetMovie(int id)
        {
            //Movie - Objekt mit Relation zur Commentar Tabell (1:n)
            Movie currentMovie = await _context.Movies.Include(c => c.MovieComments).SingleOrDefaultAsync(m => m.Id == id);

            if (currentMovie == null)
            {
                return NotFound();
            }

            //MovieDTO dto = new MovieDTO();
            //dto.Id = currentMovie.Id;
            //dto.Title = currentMovie.Title;
            //dto.Description = currentMovie.Description;
            //dto.Price = currentMovie.Price;
            //dto.IMDB_Rating = currentMovie.IMDB_Rating;
            //dto.Genre = currentMovie.Genre;
            //dto.CommentsList = currentMovie.MovieComments.ToDTOs();

            //return dto;

            return currentMovie.MovieToDTOWithRelation();
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie) //Ist Default schon aus dem Body
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
