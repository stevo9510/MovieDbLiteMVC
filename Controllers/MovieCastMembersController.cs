using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieDbLite.MVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDbLite.MVC.Controllers
{
    public class MovieCastMembersController : Controller
    {
        private readonly MovieDbLiteContext _context;

        public MovieCastMembersController(MovieDbLiteContext context)
        {
            _context = context;
        }

        // GET: MovieCastMembers
        public async Task<IActionResult> Index()
        {
            var movieDbLiteContext = _context.MovieCastMember.Include(m => m.ActorFilmMember).Include(m => m.Movie);
            return View(await movieDbLiteContext.ToListAsync());
        }

        // GET: MovieCastMembers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieCastMember = await _context.MovieCastMember
                .Include(m => m.ActorFilmMember)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieCastMember == null)
            {
                return NotFound();
            }

            return View(movieCastMember);
        }

        // GET: MovieCastMembers/Create
        public IActionResult Create()
        {
            ViewData["ActorFilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName");
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title");
            return View();
        }

        // POST: MovieCastMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,ActorFilmMemberId,CharacterName,Sequence")] MovieCastMember movieCastMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieCastMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActorFilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName", movieCastMember.ActorFilmMemberId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieCastMember.MovieId);
            return View(movieCastMember);
        }

        // GET: MovieCastMembers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieCastMember = await _context.MovieCastMember.FindAsync(id);
            if (movieCastMember == null)
            {
                return NotFound();
            }
            ViewData["ActorFilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName", movieCastMember.ActorFilmMemberId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieCastMember.MovieId);
            return View(movieCastMember);
        }

        // POST: MovieCastMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("MovieId,ActorFilmMemberId,CharacterName,Sequence")] MovieCastMember movieCastMember)
        {
            if (id != movieCastMember.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieCastMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieCastMemberExists(movieCastMember.MovieId))
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
            ViewData["ActorFilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName", movieCastMember.ActorFilmMemberId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieCastMember.MovieId);
            return View(movieCastMember);
        }

        // GET: MovieCastMembers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieCastMember = await _context.MovieCastMember
                .Include(m => m.ActorFilmMember)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieCastMember == null)
            {
                return NotFound();
            }

            return View(movieCastMember);
        }

        // POST: MovieCastMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var movieCastMember = await _context.MovieCastMember.FindAsync(id);
            _context.MovieCastMember.Remove(movieCastMember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieCastMemberExists(long id)
        {
            return _context.MovieCastMember.Any(e => e.MovieId == id);
        }
    }
}
