using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieDbLite.MVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDbLite.MVC.Controllers
{
    public class RestrictionRatingsController : Controller
    {
        private readonly MovieDbLiteContext _context;

        public RestrictionRatingsController(MovieDbLiteContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Restriction Ratings Index Page
        /// </summary>
        /// <returns></returns>
        // GET: RestrictionRatings
        public async Task<IActionResult> Index()
        {
            return View(await _context.RestrictionRating.ToListAsync());
        }

        // GET: RestrictionRatings/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restrictionRating = await _context.RestrictionRating
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restrictionRating == null)
            {
                return NotFound();
            }

            return View(restrictionRating);
        }

        // GET: RestrictionRatings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RestrictionRatings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,ShortDescription,LongDescription,IsActive")] RestrictionRating restrictionRating)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restrictionRating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(restrictionRating);
        }

        // GET: RestrictionRatings/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restrictionRating = await _context.RestrictionRating.FindAsync(id);
            if (restrictionRating == null)
            {
                return NotFound();
            }
            return View(restrictionRating);
        }

        // POST: RestrictionRatings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Id,Code,ShortDescription,LongDescription,IsActive")] RestrictionRating restrictionRating)
        {
            if (id != restrictionRating.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restrictionRating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestrictionRatingExists(restrictionRating.Id))
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
            return View(restrictionRating);
        }

        // GET: RestrictionRatings/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restrictionRating = await _context.RestrictionRating
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restrictionRating == null)
            {
                return NotFound();
            }

            return View(restrictionRating);
        }

        // POST: RestrictionRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var restrictionRating = await _context.RestrictionRating.FindAsync(id);
            _context.RestrictionRating.Remove(restrictionRating);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Used to check if a restriction rating already exists in database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool RestrictionRatingExists(short id)
        {
            return _context.RestrictionRating.Any(e => e.Id == id);
        }
    }
}
