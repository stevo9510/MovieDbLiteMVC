using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieDbLite.MVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDbLite.MVC.Controllers
{
    public class MovieCrewMembersController : Controller
    {
        private readonly MovieDbLiteContext _context;

        public MovieCrewMembersController(MovieDbLiteContext context)
        {
            _context = context;
        }

        // GET: MovieCrewMembers
        public async Task<IActionResult> Index()
        {
            var movieDbLiteContext = _context.MovieCrewMember.Include(m => m.FilmMember).Include(m => m.FilmRole).Include(m => m.Movie);
            return View(await movieDbLiteContext.ToListAsync());
        }

        // GET: MovieCrewMembers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieCrewMember = await _context.MovieCrewMember
                .Include(m => m.FilmMember)
                .Include(m => m.FilmRole)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieCrewMember == null)
            {
                return NotFound();
            }

            return View(movieCrewMember);
        }

        // GET: MovieCrewMembers/Create
        public IActionResult Create()
        {
            ViewData["FilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName");
            ViewData["FilmRoleId"] = new SelectList(_context.FilmRole, "Id", "RoleName");
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title");
            return View();
        }

        // POST: MovieCrewMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,FilmMemberId,FilmRoleId")] MovieCrewMember movieCrewMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieCrewMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName", movieCrewMember.FilmMemberId);
            ViewData["FilmRoleId"] = new SelectList(_context.FilmRole, "Id", "RoleName", movieCrewMember.FilmRoleId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieCrewMember.MovieId);
            return View(movieCrewMember);
        }

        // GET: MovieCrewMembers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieCrewMember = await _context.MovieCrewMember.FindAsync(id);
            if (movieCrewMember == null)
            {
                return NotFound();
            }
            ViewData["FilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName", movieCrewMember.FilmMemberId);
            ViewData["FilmRoleId"] = new SelectList(_context.FilmRole, "Id", "RoleName", movieCrewMember.FilmRoleId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieCrewMember.MovieId);
            return View(movieCrewMember);
        }

        // POST: MovieCrewMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("MovieId,FilmMemberId,FilmRoleId")] MovieCrewMember movieCrewMember)
        {
            if (id != movieCrewMember.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieCrewMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieCrewMemberExists(movieCrewMember.MovieId))
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
            ViewData["FilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName", movieCrewMember.FilmMemberId);
            ViewData["FilmRoleId"] = new SelectList(_context.FilmRole, "Id", "RoleName", movieCrewMember.FilmRoleId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieCrewMember.MovieId);
            return View(movieCrewMember);
        }

        // GET: MovieCrewMembers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieCrewMember = await _context.MovieCrewMember
                .Include(m => m.FilmMember)
                .Include(m => m.FilmRole)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieCrewMember == null)
            {
                return NotFound();
            }

            return View(movieCrewMember);
        }

        // POST: MovieCrewMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var movieCrewMember = await _context.MovieCrewMember.FindAsync(id);
            _context.MovieCrewMember.Remove(movieCrewMember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieCrewMemberExists(long id)
        {
            return _context.MovieCrewMember.Any(e => e.MovieId == id);
        }
    }
}
