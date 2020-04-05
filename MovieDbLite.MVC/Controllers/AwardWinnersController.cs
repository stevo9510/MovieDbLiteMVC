﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieDbLite.MVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDbLite.MVC.Controllers
{
    public class AwardWinnersController : Controller
    {
        private readonly MovieDbLiteContext _context;

        public AwardWinnersController(MovieDbLiteContext context)
        {
            _context = context;
        }

        // GET: AwardWinners
        public async Task<IActionResult> Index()
        {
            var movieDbLiteContext = _context.AwardWinner.Include(a => a.Award).Include(a => a.AwardShowInstance).Include(a => a.FilmMember).Include(a => a.Movie);
            return View(await movieDbLiteContext.ToListAsync());
        }

        // GET: AwardWinners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awardWinner = await _context.AwardWinner
                .Include(a => a.Award)
                .Include(a => a.AwardShowInstance)
                .Include(a => a.FilmMember)
                .Include(a => a.Movie)
                .FirstOrDefaultAsync(m => m.AwardShowInstanceId == id);
            if (awardWinner == null)
            {
                return NotFound();
            }

            return View(awardWinner);
        }

        // GET: AwardWinners/Create
        public IActionResult Create()
        {
            ViewData["AwardId"] = new SelectList(_context.Award, "Id", "AwardName");
            ViewData["AwardShowInstanceId"] = new SelectList(_context.AwardShowInstance.Include(f => f.AwardShow), "Id", nameof(AwardShowInstance.FriendlyName));
            ViewData["FilmMemberId"] = new SelectList(_context.FilmMember, "Id", nameof(FilmMember.PreferredFullName));
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", nameof(Movie.Title));
            return View();
        }

        // POST: AwardWinners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AwardShowInstanceId,AwardId,FilmMemberId,MovieId")] AwardWinner awardWinner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(awardWinner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AwardId"] = new SelectList(_context.Award, "Id", "AwardName", awardWinner.AwardId);
            ViewData["AwardShowInstanceId"] = new SelectList(_context.AwardShowInstance, "Id", "Id", awardWinner.AwardShowInstanceId);
            ViewData["FilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName", awardWinner.FilmMemberId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Description", awardWinner.MovieId);
            return View(awardWinner);
        }

        // GET: AwardWinners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awardWinner = await _context.AwardWinner.FindAsync(id);
            if (awardWinner == null)
            {
                return NotFound();
            }
            ViewData["AwardId"] = new SelectList(_context.Award, "Id", "AwardName", awardWinner.AwardId);
            ViewData["AwardShowInstanceId"] = new SelectList(_context.AwardShowInstance, "Id", "Id", awardWinner.AwardShowInstanceId);
            ViewData["FilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName", awardWinner.FilmMemberId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Description", awardWinner.MovieId);
            return View(awardWinner);
        }

        // POST: AwardWinners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AwardShowInstanceId,AwardId,FilmMemberId,MovieId")] AwardWinner awardWinner)
        {
            if (id != awardWinner.AwardShowInstanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(awardWinner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AwardWinnerExists(awardWinner.AwardShowInstanceId))
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
            ViewData["AwardId"] = new SelectList(_context.Award, "Id", "AwardName", awardWinner.AwardId);
            ViewData["AwardShowInstanceId"] = new SelectList(_context.AwardShowInstance, "Id", "Id", awardWinner.AwardShowInstanceId);
            ViewData["FilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName", awardWinner.FilmMemberId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Description", awardWinner.MovieId);
            return View(awardWinner);
        }

        // GET: AwardWinners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awardWinner = await _context.AwardWinner
                .Include(a => a.Award)
                .Include(a => a.AwardShowInstance)
                .Include(a => a.FilmMember)
                .Include(a => a.Movie)
                .FirstOrDefaultAsync(m => m.AwardShowInstanceId == id);
            if (awardWinner == null)
            {
                return NotFound();
            }

            return View(awardWinner);
        }

        // POST: AwardWinners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var awardWinner = await _context.AwardWinner.FindAsync(id);
            _context.AwardWinner.Remove(awardWinner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AwardWinnerExists(int id)
        {
            return _context.AwardWinner.Any(e => e.AwardShowInstanceId == id);
        }
    }
}
