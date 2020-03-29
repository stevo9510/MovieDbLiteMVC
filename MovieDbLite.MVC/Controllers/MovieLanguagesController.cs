using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieDbLite.MVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDbLite.MVC.Controllers
{
    public class MovieLanguagesController : Controller
    {
        private readonly MovieDbLiteContext _context;

        public MovieLanguagesController(MovieDbLiteContext context)
        {
            _context = context;
        }

        // GET: MovieLanguages
        public async Task<IActionResult> Index()
        {
            var movieDbLiteContext = _context.MovieLanguage.Include(m => m.LanguageIsoCodeNavigation).Include(m => m.Movie);
            return View(await movieDbLiteContext.ToListAsync());
        }

        // GET: MovieLanguages/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieLanguage = await _context.MovieLanguage
                .Include(m => m.LanguageIsoCodeNavigation)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieLanguage == null)
            {
                return NotFound();
            }

            return View(movieLanguage);
        }

        // GET: MovieLanguages/Create
        public IActionResult Create()
        {
            ViewData["LanguageIsoCode"] = new SelectList(_context.Language, "LanguageIsoCode", "LanguageIsoCode");
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Description");
            return View();
        }

        // POST: MovieLanguages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,LanguageIsoCode")] MovieLanguage movieLanguage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieLanguage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LanguageIsoCode"] = new SelectList(_context.Language, "LanguageIsoCode", "LanguageIsoCode", movieLanguage.LanguageIsoCode);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Description", movieLanguage.MovieId);
            return View(movieLanguage);
        }

        // GET: MovieLanguages/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieLanguage = await _context.MovieLanguage.FindAsync(id);
            if (movieLanguage == null)
            {
                return NotFound();
            }
            ViewData["LanguageIsoCode"] = new SelectList(_context.Language, "LanguageIsoCode", "LanguageIsoCode", movieLanguage.LanguageIsoCode);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Description", movieLanguage.MovieId);
            return View(movieLanguage);
        }

        // POST: MovieLanguages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("MovieId,LanguageIsoCode")] MovieLanguage movieLanguage)
        {
            if (id != movieLanguage.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieLanguage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieLanguageExists(movieLanguage.MovieId))
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
            ViewData["LanguageIsoCode"] = new SelectList(_context.Language, "LanguageIsoCode", "LanguageIsoCode", movieLanguage.LanguageIsoCode);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Description", movieLanguage.MovieId);
            return View(movieLanguage);
        }

        // GET: MovieLanguages/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieLanguage = await _context.MovieLanguage
                .Include(m => m.LanguageIsoCodeNavigation)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieLanguage == null)
            {
                return NotFound();
            }

            return View(movieLanguage);
        }

        // POST: MovieLanguages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var movieLanguage = await _context.MovieLanguage.FindAsync(id);
            _context.MovieLanguage.Remove(movieLanguage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieLanguageExists(long id)
        {
            return _context.MovieLanguage.Any(e => e.MovieId == id);
        }
    }
}
