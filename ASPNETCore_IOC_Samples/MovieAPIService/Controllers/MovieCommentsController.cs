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

namespace MovieAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieCommentsController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public MovieCommentsController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: api/MovieComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieCustomerComments>>> GetMovieCustomerComments()
        {
            return await _context.MovieCustomerComments.ToListAsync();
        }


        // GET: api/MovieComments
        [HttpGet("UpdateMovieCommmentList/{id}")]
        public async Task<ActionResult<IEnumerable<MovieCustomerComments>>> UpdateMovieCustomerComments(int id)
        {
            return await _context.MovieCustomerComments.Where(comments => comments.MovieId == id).ToListAsync();
        }

        // GET: api/MovieComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieCustomerComments>> GetMovieCustomerComments(int id)
        {
            var movieCustomerComments = await _context.MovieCustomerComments.FindAsync(id);

            if (movieCustomerComments == null)
            {
                return NotFound();
            }

            return movieCustomerComments;
        }

        // PUT: api/MovieComments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieCustomerComments(int id, MovieCustomerComments movieCustomerComments)
        {
            if (id != movieCustomerComments.Id)
            {
                return BadRequest();
            }

            _context.Entry(movieCustomerComments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieCustomerCommentsExists(id))
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

        // POST: api/MovieComments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieCustomerComments>> PostMovieCustomerComments(InsertCommentDTO insertCommentDTO)
        {

            MovieCustomerComments newComment = new() { Comment = insertCommentDTO.Commentar, MovieId = insertCommentDTO.MovieId };

            _context.MovieCustomerComments.Add(newComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovieCustomerComments", new { id = newComment.Id }, newComment);
        }

        // DELETE: api/MovieComments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieCustomerComments(int id)
        {
            var movieCustomerComments = await _context.MovieCustomerComments.FindAsync(id);
            if (movieCustomerComments == null)
            {
                return NotFound();
            }

            _context.MovieCustomerComments.Remove(movieCustomerComments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieCustomerCommentsExists(int id)
        {
            return _context.MovieCustomerComments.Any(e => e.Id == id);
        }
    }
}
