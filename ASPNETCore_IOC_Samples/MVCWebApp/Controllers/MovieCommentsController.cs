using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCWebApp.Data;
using MVCWebApp.Models;

namespace MVCWebApp.Controllers
{
    public class MovieCommentsController : Controller
    {
        private readonly MovieDbContext _context;

        public MovieCommentsController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: MovieComments
        public async Task<IActionResult> Index()
        {
            var movieDbContext = _context.MovieCustomerComments.Include(m => m.MovieRef);
            return View(await movieDbContext.ToListAsync());
        }

        // GET: MovieComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MovieCustomerComments == null)
            {
                return NotFound();
            }

            var movieCustomerComments = await _context.MovieCustomerComments
                .Include(m => m.MovieRef)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieCustomerComments == null)
            {
                return NotFound();
            }

            return View(movieCustomerComments);
        }

        // GET: MovieComments/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title");
            return View();
        }

        // POST: MovieComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Comment,MovieId")] MovieCustomerComments movieCustomerComments)
        {
            ModelState.Remove("MovieRef");
            if (ModelState.IsValid)
            {
                _context.Add(movieCustomerComments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieCustomerComments.MovieId);
            return View(movieCustomerComments);
        }

        // GET: MovieComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MovieCustomerComments == null)
            {
                return NotFound();
            }

            var movieCustomerComments = await _context.MovieCustomerComments.FindAsync(id);
            if (movieCustomerComments == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieCustomerComments.MovieId);
            return View(movieCustomerComments);
        }

        // POST: MovieComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Comment,MovieId")] MovieCustomerComments movieCustomerComments)
        {
            if (id != movieCustomerComments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieCustomerComments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieCustomerCommentsExists(movieCustomerComments.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieCustomerComments.MovieId);
            return View(movieCustomerComments);
        }

        // GET: MovieComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MovieCustomerComments == null)
            {
                return NotFound();
            }

            var movieCustomerComments = await _context.MovieCustomerComments
                .Include(m => m.MovieRef)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieCustomerComments == null)
            {
                return NotFound();
            }

            return View(movieCustomerComments);
        }

        // POST: MovieComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MovieCustomerComments == null)
            {
                return Problem("Entity set 'MovieDbContext.MovieCustomerComments'  is null.");
            }
            var movieCustomerComments = await _context.MovieCustomerComments.FindAsync(id);
            if (movieCustomerComments != null)
            {
                _context.MovieCustomerComments.Remove(movieCustomerComments);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieCustomerCommentsExists(int id)
        {
          return (_context.MovieCustomerComments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
