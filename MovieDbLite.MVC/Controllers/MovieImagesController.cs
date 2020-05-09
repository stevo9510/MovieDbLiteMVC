using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieDbLite.MVC.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDbLite.MVC.Controllers
{
    public class MovieImagesController : Controller
    {
        private readonly MovieDbLiteContext _context;

        public MovieImagesController(MovieDbLiteContext context)
        {
            _context = context;
        }

        // GET: MovieImages
        public async Task<IActionResult> Index()
        {
            var movieDbLiteContext = _context.MovieImage.Include(m => m.ImageType).Include(m => m.Movie);
            return View(await movieDbLiteContext.ToListAsync());
        }

        // GET: MovieImages/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieImage = await _context.MovieImage
                .Include(m => m.ImageType)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieImage == null)
            {
                return NotFound();
            }

            return View(movieImage);
        }

        // GET: MovieImages/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title");
            return View();
        }

        // POST: MovieImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieImage movieImage, IFormFile fileContents)
        {
            // set FileContents
            using var ms = new MemoryStream();
            fileContents.CopyTo(ms);
            byte[] fileBytes = ms.ToArray();
            movieImage.FileContents = fileBytes;

            // set file extension
            string fileExtension = new FileInfo(fileContents.FileName).Extension;
            ImageType imageType = await _context.ImageType.Where(i => i.ImageExtension == fileExtension).FirstOrDefaultAsync();
            movieImage.ImageTypeId = imageType.Id;

            // timestamp (note: not UTC for now)
            movieImage.DateUploaded = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(movieImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ImageTypeId"] = new SelectList(_context.ImageType, "Id", "ImageExtension", movieImage.ImageTypeId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieImage.MovieId);
            return View(movieImage);
        }

        // GET: MovieImages/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieImage = await _context.MovieImage.FindAsync(id);
            if (movieImage == null)
            {
                return NotFound();
            }
            ViewData["ImageTypeId"] = new SelectList(_context.ImageType, "Id", "ImageExtension", movieImage.ImageTypeId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieImage.MovieId);
            return View(movieImage);
        }

        // POST: MovieImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,MovieId,ImageName,ImageTypeId,Description,FileContents,DateUploaded")] MovieImage movieImage)
        {
            if (id != movieImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieImageExists(movieImage.Id))
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
            ViewData["ImageTypeId"] = new SelectList(_context.ImageType, "Id", "ImageExtension", movieImage.ImageTypeId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", movieImage.MovieId);
            return View(movieImage);
        }

        // GET: MovieImages/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieImage = await _context.MovieImage
                .Include(m => m.ImageType)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieImage == null)
            {
                return NotFound();
            }

            return View(movieImage);
        }

        // POST: MovieImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var movieImage = await _context.MovieImage.FindAsync(id);
            _context.MovieImage.Remove(movieImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieImageExists(long id)
        {
            return _context.MovieImage.Any(e => e.Id == id);
        }
    }
}
