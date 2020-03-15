using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieDbLite.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDbLite.Controllers
{
    public class MovieUserReviewHelpfulsController : Controller
    {
        private readonly MovieDbLiteContext _context;

        public MovieUserReviewHelpfulsController(MovieDbLiteContext context)
        {
            _context = context;
        }

        // GET: MovieUserReviewHelpfuls
        public async Task<IActionResult> Index()
        {
            var movieDbLiteContext = _context.MovieUserReviewHelpful.Include(m => m.MovieUserReview).Include(m => m.User);
            return View(await movieDbLiteContext.ToListAsync());
        }

        // GET: MovieUserReviewHelpfuls/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieUserReviewHelpful = await _context.MovieUserReviewHelpful
                .Include(m => m.MovieUserReview)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.MovieUserReviewId == id);
            if (movieUserReviewHelpful == null)
            {
                return NotFound();
            }

            return View(movieUserReviewHelpful);
        }

        // GET: MovieUserReviewHelpfuls/Create
        public IActionResult Create()
        {
            ViewData["MovieUserReviewId"] = new SelectList(_context.MovieUserReview, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "EmailAddress");
            return View();
        }

        // POST: MovieUserReviewHelpfuls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieUserReviewId,UserId,Helpful")] MovieUserReviewHelpful movieUserReviewHelpful)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieUserReviewHelpful);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieUserReviewId"] = new SelectList(_context.MovieUserReview, "Id", "Id", movieUserReviewHelpful.MovieUserReviewId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "EmailAddress", movieUserReviewHelpful.UserId);
            return View(movieUserReviewHelpful);
        }

        // GET: MovieUserReviewHelpfuls/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieUserReviewHelpful = await _context.MovieUserReviewHelpful.FindAsync(id);
            if (movieUserReviewHelpful == null)
            {
                return NotFound();
            }
            ViewData["MovieUserReviewId"] = new SelectList(_context.MovieUserReview, "Id", "Id", movieUserReviewHelpful.MovieUserReviewId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "EmailAddress", movieUserReviewHelpful.UserId);
            return View(movieUserReviewHelpful);
        }

        // POST: MovieUserReviewHelpfuls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("MovieUserReviewId,UserId,Helpful")] MovieUserReviewHelpful movieUserReviewHelpful)
        {
            if (id != movieUserReviewHelpful.MovieUserReviewId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieUserReviewHelpful);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieUserReviewHelpfulExists(movieUserReviewHelpful.MovieUserReviewId))
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
            ViewData["MovieUserReviewId"] = new SelectList(_context.MovieUserReview, "Id", "Id", movieUserReviewHelpful.MovieUserReviewId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "EmailAddress", movieUserReviewHelpful.UserId);
            return View(movieUserReviewHelpful);
        }

        // GET: MovieUserReviewHelpfuls/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieUserReviewHelpful = await _context.MovieUserReviewHelpful
                .Include(m => m.MovieUserReview)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.MovieUserReviewId == id);
            if (movieUserReviewHelpful == null)
            {
                return NotFound();
            }

            return View(movieUserReviewHelpful);
        }

        // POST: MovieUserReviewHelpfuls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var movieUserReviewHelpful = await _context.MovieUserReviewHelpful.FindAsync(id);
            _context.MovieUserReviewHelpful.Remove(movieUserReviewHelpful);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieUserReviewHelpfulExists(long id)
        {
            return _context.MovieUserReviewHelpful.Any(e => e.MovieUserReviewId == id);
        }
    }
}
