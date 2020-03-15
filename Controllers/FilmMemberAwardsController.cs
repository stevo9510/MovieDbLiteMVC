using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieDbLite.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDbLite.Controllers
{
    public class FilmMemberAwardsController : Controller
    {
        private readonly MovieDbLiteContext _context;

        public FilmMemberAwardsController(MovieDbLiteContext context)
        {
            _context = context;
        }

        // GET: FilmMemberAwards
        public async Task<IActionResult> Index()
        {
            var movieDbLiteContext = _context.FilmMemberAward.Include(f => f.Award).Include(f => f.FilmMember).Include(f => f.Movie);
            return View(await movieDbLiteContext.ToListAsync());
        }

        // GET: FilmMemberAwards/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmMemberAward = await _context.FilmMemberAward
                .Include(f => f.Award)
                .Include(f => f.FilmMember)
                .Include(f => f.Movie)
                .FirstOrDefaultAsync(m => m.FilmMemberId == id);
            if (filmMemberAward == null)
            {
                return NotFound();
            }

            return View(filmMemberAward);
        }

        // GET: FilmMemberAwards/Create
        public IActionResult Create()
        {
            ViewData["AwardId"] = new SelectList(_context.Award, "Id", "AwardName");
            ViewData["FilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName");
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title");
            return View();
        }

        // POST: FilmMemberAwards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FilmMemberId,AwardId,MovieId,Year,DateReceived")] FilmMemberAward filmMemberAward)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmMemberAward);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AwardId"] = new SelectList(_context.Award, "Id", "AwardName", filmMemberAward.AwardId);
            ViewData["FilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName", filmMemberAward.FilmMemberId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", filmMemberAward.MovieId);
            return View(filmMemberAward);
        }

        // GET: FilmMemberAwards/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmMemberAward = await _context.FilmMemberAward.FindAsync(id);
            if (filmMemberAward == null)
            {
                return NotFound();
            }
            ViewData["AwardId"] = new SelectList(_context.Award, "Id", "AwardName", filmMemberAward.AwardId);
            ViewData["FilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName", filmMemberAward.FilmMemberId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", filmMemberAward.MovieId);
            return View(filmMemberAward);
        }

        // POST: FilmMemberAwards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("FilmMemberId,AwardId,MovieId,Year,DateReceived")] FilmMemberAward filmMemberAward)
        {
            if (id != filmMemberAward.FilmMemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmMemberAward);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmMemberAwardExists(filmMemberAward.FilmMemberId))
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
            ViewData["AwardId"] = new SelectList(_context.Award, "Id", "AwardName", filmMemberAward.AwardId);
            ViewData["FilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName", filmMemberAward.FilmMemberId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", filmMemberAward.MovieId);
            return View(filmMemberAward);
        }

        // GET: FilmMemberAwards/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmMemberAward = await _context.FilmMemberAward
                .Include(f => f.Award)
                .Include(f => f.FilmMember)
                .Include(f => f.Movie)
                .FirstOrDefaultAsync(m => m.FilmMemberId == id);
            if (filmMemberAward == null)
            {
                return NotFound();
            }

            return View(filmMemberAward);
        }

        // POST: FilmMemberAwards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var filmMemberAward = await _context.FilmMemberAward.FindAsync(id);
            _context.FilmMemberAward.Remove(filmMemberAward);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmMemberAwardExists(long id)
        {
            return _context.FilmMemberAward.Any(e => e.FilmMemberId == id);
        }
    }
}
