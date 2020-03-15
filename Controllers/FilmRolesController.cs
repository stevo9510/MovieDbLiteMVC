using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieDbLite.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDbLite.Controllers
{
    public class FilmRolesController : Controller
    {
        private readonly MovieDbLiteContext _context;

        public FilmRolesController(MovieDbLiteContext context)
        {
            _context = context;
        }

        // GET: FilmRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.FilmRole.ToListAsync());
        }

        // GET: FilmRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmRole = await _context.FilmRole
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmRole == null)
            {
                return NotFound();
            }

            return View(filmRole);
        }

        // GET: FilmRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FilmRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoleName,Description")] FilmRole filmRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmRole);
        }

        // GET: FilmRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmRole = await _context.FilmRole.FindAsync(id);
            if (filmRole == null)
            {
                return NotFound();
            }
            return View(filmRole);
        }

        // POST: FilmRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoleName,Description")] FilmRole filmRole)
        {
            if (id != filmRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmRoleExists(filmRole.Id))
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
            return View(filmRole);
        }

        // GET: FilmRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmRole = await _context.FilmRole
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmRole == null)
            {
                return NotFound();
            }

            return View(filmRole);
        }

        // POST: FilmRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filmRole = await _context.FilmRole.FindAsync(id);
            _context.FilmRole.Remove(filmRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmRoleExists(int id)
        {
            return _context.FilmRole.Any(e => e.Id == id);
        }
    }
}
