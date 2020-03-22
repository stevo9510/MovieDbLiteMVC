using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieDbLite.MVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDbLite.MVC.Controllers
{
    public class FilmMembersController : Controller
    {
        private readonly MovieDbLiteContext _context;

        public FilmMembersController(MovieDbLiteContext context)
        {
            _context = context;
        }

        // GET: FilmMembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.FilmMember.ToListAsync());
        }

        // GET: FilmMembers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmMember = await _context.FilmMember
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmMember == null)
            {
                return NotFound();
            }

            return View(filmMember);
        }

        // GET: FilmMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FilmMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Prefix,FirstName,MiddleName,LastName,Suffix,PreferredFullName,Gender,DateOfBirth,DateOfDeath,Biography")] FilmMember filmMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmMember);
        }

        // GET: FilmMembers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmMember = await _context.FilmMember.FindAsync(id);
            if (filmMember == null)
            {
                return NotFound();
            }
            return View(filmMember);
        }

        // POST: FilmMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Prefix,FirstName,MiddleName,LastName,Suffix,PreferredFullName,Gender,DateOfBirth,DateOfDeath,Biography")] FilmMember filmMember)
        {
            if (id != filmMember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmMemberExists(filmMember.Id))
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
            return View(filmMember);
        }

        // GET: FilmMembers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmMember = await _context.FilmMember
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmMember == null)
            {
                return NotFound();
            }

            return View(filmMember);
        }

        // POST: FilmMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var filmMember = await _context.FilmMember.FindAsync(id);
            _context.FilmMember.Remove(filmMember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmMemberExists(long id)
        {
            return _context.FilmMember.Any(e => e.Id == id);
        }
    }
}
