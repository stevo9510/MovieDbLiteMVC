using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieDbLite.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDbLite.Controllers
{
    public class AwardShowsController : Controller
    {
        private readonly MovieDbLiteContext _context;

        public AwardShowsController(MovieDbLiteContext context)
        {
            _context = context;
        }

        // GET: AwardShows
        public async Task<IActionResult> Index()
        {
            return View(await _context.AwardShow.ToListAsync());
        }

        // GET: AwardShows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awardShow = await _context.AwardShow
                .FirstOrDefaultAsync(m => m.Id == id);
            if (awardShow == null)
            {
                return NotFound();
            }

            return View(awardShow);
        }

        // GET: AwardShows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AwardShows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShowName,Description")] AwardShow awardShow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(awardShow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(awardShow);
        }

        // GET: AwardShows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awardShow = await _context.AwardShow.FindAsync(id);
            if (awardShow == null)
            {
                return NotFound();
            }
            return View(awardShow);
        }

        // POST: AwardShows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShowName,Description")] AwardShow awardShow)
        {
            if (id != awardShow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(awardShow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AwardShowExists(awardShow.Id))
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
            return View(awardShow);
        }

        // GET: AwardShows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awardShow = await _context.AwardShow
                .FirstOrDefaultAsync(m => m.Id == id);
            if (awardShow == null)
            {
                return NotFound();
            }

            return View(awardShow);
        }

        // POST: AwardShows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var awardShow = await _context.AwardShow.FindAsync(id);
            _context.AwardShow.Remove(awardShow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AwardShowExists(int id)
        {
            return _context.AwardShow.Any(e => e.Id == id);
        }
    }
}
