using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieDbLite.MVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDbLite.MVC.Controllers
{
    public class AwardShowInstancesController : Controller
    {
        private readonly MovieDbLiteContext _context;

        public AwardShowInstancesController(MovieDbLiteContext context)
        {
            _context = context;
        }

        // POST: AwardShowInstances/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AwardShowInstance awardShowInstance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(awardShowInstance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AwardShowId"] = new SelectList(_context.AwardShow, "Id", "ShowName", awardShowInstance.AwardShowId);
            return View(awardShowInstance);
        }

        // GET: AwardShowInstances
        public async Task<IActionResult> Index()
        {
            var movieDbLiteContext = _context.AwardShowInstance.Include(a => a.AwardShow);
            return View(await movieDbLiteContext.ToListAsync());
        }

        // GET: AwardShowInstances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awardShowInstance = await _context.AwardShowInstance
                .Include(a => a.AwardShow)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (awardShowInstance == null)
            {
                return NotFound();
            }

            return View(awardShowInstance);
        }

        // GET: AwardShowInstances/Create
        public IActionResult Create()
        {
            ViewData["AwardShowId"] = new SelectList(_context.AwardShow, "Id", "ShowName");
            return View();
        }

        // GET: AwardShowInstances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awardShowInstance = await _context.AwardShowInstance.FindAsync(id);
            if (awardShowInstance == null)
            {
                return NotFound();
            }
            ViewData["AwardShowId"] = new SelectList(_context.AwardShow, "Id", "ShowName", awardShowInstance.AwardShowId);
            return View(awardShowInstance);
        }

        // POST: AwardShowInstances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AwardShowId,Year,DateHosted")] AwardShowInstance awardShowInstance)
        {
            if (id != awardShowInstance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(awardShowInstance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AwardShowInstanceExists(awardShowInstance.Id))
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
            ViewData["AwardShowId"] = new SelectList(_context.AwardShow, "Id", "ShowName", awardShowInstance.AwardShowId);
            return View(awardShowInstance);
        }

        // GET: AwardShowInstances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awardShowInstance = await _context.AwardShowInstance
                .Include(a => a.AwardShow)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (awardShowInstance == null)
            {
                return NotFound();
            }

            return View(awardShowInstance);
        }

        // POST: AwardShowInstances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var awardShowInstance = await _context.AwardShowInstance.FindAsync(id);
            _context.AwardShowInstance.Remove(awardShowInstance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AwardShowInstanceExists(int id)
        {
            return _context.AwardShowInstance.Any(e => e.Id == id);
        }
    }
}
