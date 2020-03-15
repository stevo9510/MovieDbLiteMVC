using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieDbLite.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDbLite.Controllers
{
    public class MovieActorsController : Controller
    {
        private readonly MovieDbLiteContext _context;

        public MovieActorsController(MovieDbLiteContext context)
        {
            _context = context;
        }

        // GET: MovieActors
        public async Task<IActionResult> Index()
        {
            var movieDbLiteContext = _context.MovieActor.Include(m => m.ActorFilmMember).Include(m => m.Movie);
            return View(await movieDbLiteContext.ToListAsync());
        }

        // GET: MovieActors/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieActor = await _context.MovieActor
                .Include(m => m.ActorFilmMember)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieActor == null)
            {
                return NotFound();
            }

            return View(movieActor);
        }

        // GET: MovieActors/Create
        public IActionResult Create()
        {
            ViewData["ActorFilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName");
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title");
            return View();
        }

        // POST: MovieActors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,ActorFilmMemberId,RoleName,Sequence")] MovieActor movieActor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieActor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActorFilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName", movieActor.ActorFilmMemberId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieActor.MovieId);
            return View(movieActor);
        }

        // GET: MovieActors/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieActor = await _context.MovieActor.FindAsync(id);
            if (movieActor == null)
            {
                return NotFound();
            }
            ViewData["ActorFilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName", movieActor.ActorFilmMemberId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieActor.MovieId);
            return View(movieActor);
        }

        // POST: MovieActors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("MovieId,ActorFilmMemberId,RoleName,Sequence")] MovieActor movieActor)
        {
            if (id != movieActor.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieActor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieActorExists(movieActor.MovieId))
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
            ViewData["ActorFilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName", movieActor.ActorFilmMemberId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieActor.MovieId);
            return View(movieActor);
        }

        // GET: MovieActors/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieActor = await _context.MovieActor
                .Include(m => m.ActorFilmMember)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieActor == null)
            {
                return NotFound();
            }

            return View(movieActor);
        }

        // POST: MovieActors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var movieActor = await _context.MovieActor.FindAsync(id);
            _context.MovieActor.Remove(movieActor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieActorExists(long id)
        {
            return _context.MovieActor.Any(e => e.MovieId == id);
        }
    }
}
