using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieDbLite.MVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDbLite.MVC.Controllers
{
    public class MovieUserReviewsController : Controller
    {
        private readonly MovieDbLiteContext _context;

        public MovieUserReviewsController(MovieDbLiteContext context)
        {
            _context = context;
        }

        // GET: MovieUserReviews
        public async Task<IActionResult> Index()
        {
            var movieDbLiteContext = _context.MovieUserReview.Include(m => m.Movie).Include(m => m.User);
            return View(await movieDbLiteContext.ToListAsync());
        }

        // GET: MovieUserReviews/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieUserReview = await _context.MovieUserReview
                .Include(m => m.Movie)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieUserReview == null)
            {
                return NotFound();
            }

            return View(movieUserReview);
        }

        // GET: MovieUserReviews/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "EmailAddress");
            return View();
        }

        // POST: MovieUserReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovieId,UserId,Rating,Review,DatePosted")] MovieUserReview movieUserReview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieUserReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieUserReview.MovieId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "EmailAddress", movieUserReview.UserId);
            return View(movieUserReview);
        }

        // GET: MovieUserReviews/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieUserReview = await _context.MovieUserReview.FindAsync(id);
            if (movieUserReview == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieUserReview.MovieId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "EmailAddress", movieUserReview.UserId);
            return View(movieUserReview);
        }

        // POST: MovieUserReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,MovieId,UserId,Rating,Review,DatePosted")] MovieUserReview movieUserReview)
        {
            if (id != movieUserReview.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieUserReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieUserReviewExists(movieUserReview.Id))
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
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieUserReview.MovieId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "EmailAddress", movieUserReview.UserId);
            return View(movieUserReview);
        }

        // GET: MovieUserReviews/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieUserReview = await _context.MovieUserReview
                .Include(m => m.Movie)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieUserReview == null)
            {
                return NotFound();
            }

            return View(movieUserReview);
        }

        // POST: MovieUserReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var movieUserReview = await _context.MovieUserReview.FindAsync(id);
            _context.MovieUserReview.Remove(movieUserReview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieUserReviewExists(long id)
        {
            return _context.MovieUserReview.Any(e => e.Id == id);
        }
    }
}
