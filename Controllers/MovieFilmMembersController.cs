using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieDbLite.MVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDbLite.MVC.Controllers
{
    public class MovieFilmMembersController : Controller
    {
        private readonly MovieDbLiteContext _context;

        public MovieFilmMembersController(MovieDbLiteContext context)
        {
            _context = context;
        }

        // GET: MovieFilmMembers
        public async Task<IActionResult> Index()
        {
            var movieDbLiteContext = _context.MovieFilmMember.Include(m => m.FilmMember).Include(m => m.FilmRole).Include(m => m.Movie);
            return View(await movieDbLiteContext.ToListAsync());
        }

        // GET: MovieFilmMembers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieFilmMember = await _context.MovieFilmMember
                .Include(m => m.FilmMember)
                .Include(m => m.FilmRole)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieFilmMember == null)
            {
                return NotFound();
            }

            return View(movieFilmMember);
        }

        // GET: MovieFilmMembers/Create
        public IActionResult Create()
        {
            ViewData["FilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName");
            ViewData["FilmRoleId"] = new SelectList(_context.FilmRole, "Id", "RoleName");
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title");
            return View();
        }

        // POST: MovieFilmMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,FilmMemberId,FilmRoleId")] MovieFilmMember movieFilmMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieFilmMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName", movieFilmMember.FilmMemberId);
            ViewData["FilmRoleId"] = new SelectList(_context.FilmRole, "Id", "RoleName", movieFilmMember.FilmRoleId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieFilmMember.MovieId);
            return View(movieFilmMember);
        }

        // GET: MovieFilmMembers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieFilmMember = await _context.MovieFilmMember.FindAsync(id);
            if (movieFilmMember == null)
            {
                return NotFound();
            }
            ViewData["FilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName", movieFilmMember.FilmMemberId);
            ViewData["FilmRoleId"] = new SelectList(_context.FilmRole, "Id", "RoleName", movieFilmMember.FilmRoleId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieFilmMember.MovieId);
            return View(movieFilmMember);
        }

        // POST: MovieFilmMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("MovieId,FilmMemberId,FilmRoleId")] MovieFilmMember movieFilmMember)
        {
            if (id != movieFilmMember.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieFilmMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieFilmMemberExists(movieFilmMember.MovieId))
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
            ViewData["FilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName", movieFilmMember.FilmMemberId);
            ViewData["FilmRoleId"] = new SelectList(_context.FilmRole, "Id", "RoleName", movieFilmMember.FilmRoleId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieFilmMember.MovieId);
            return View(movieFilmMember);
        }

        // GET: MovieFilmMembers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieFilmMember = await _context.MovieFilmMember
                .Include(m => m.FilmMember)
                .Include(m => m.FilmRole)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieFilmMember == null)
            {
                return NotFound();
            }

            return View(movieFilmMember);
        }

        // POST: MovieFilmMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var movieFilmMember = await _context.MovieFilmMember.FindAsync(id);
            _context.MovieFilmMember.Remove(movieFilmMember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieFilmMemberExists(long id)
        {
            return _context.MovieFilmMember.Any(e => e.MovieId == id);
        }
    }
}
