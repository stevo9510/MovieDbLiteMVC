using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieDbLite.MVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDbLite.MVC.Controllers
{
    public class MovieGenresController : Controller
    {
        private readonly MovieDbLiteContext _context;

        public MovieGenresController(MovieDbLiteContext context)
        {
            _context = context;
        }

        // GET: MovieGenres
        public async Task<IActionResult> Index()
        {
            var movieDbLiteContext = _context.MovieGenre.Include(m => m.Genre).Include(m => m.Movie);
            return View(await movieDbLiteContext.ToListAsync());
        }

        // GET: MovieGenres/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieGenre = await _context.MovieGenre
                .Include(m => m.Genre)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieGenre == null)
            {
                return NotFound();
            }

            return View(movieGenre);
        }

        // GET: MovieGenres/Create
        public IActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "GenreName");
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title");
            return View();
        }

        // POST: MovieGenres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,GenreId")] MovieGenre movieGenre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieGenre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "GenreName", movieGenre.GenreId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieGenre.MovieId);
            return View(movieGenre);
        }

        // GET: MovieGenres/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieGenre = await _context.MovieGenre.FindAsync(id);
            if (movieGenre == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "GenreName", movieGenre.GenreId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieGenre.MovieId);
            return View(movieGenre);
        }

        // POST: MovieGenres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("MovieId,GenreId")] MovieGenre movieGenre)
        {
            if (id != movieGenre.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieGenre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieGenreExists(movieGenre.MovieId))
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
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "GenreName", movieGenre.GenreId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieGenre.MovieId);
            return View(movieGenre);
        }

        // GET: MovieGenres/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieGenre = await _context.MovieGenre
                .Include(m => m.Genre)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieGenre == null)
            {
                return NotFound();
            }

            return View(movieGenre);
        }

        // POST: MovieGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var movieGenre = await _context.MovieGenre.FindAsync(id);
            _context.MovieGenre.Remove(movieGenre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieGenreExists(long id)
        {
            return _context.MovieGenre.Any(e => e.MovieId == id);
        }
    }
}
