using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MovieDbLite.MVC.Models;
using MovieDbLite.MVC.ViewModels;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDbLite.MVC.Controllers
{
    public class AwardWinnersController : Controller
    {
        private readonly MovieDbLiteContext _context;
        private readonly IMapper _mapper;

        public AwardWinnersController(MovieDbLiteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: AwardWinners
        public async Task<IActionResult> Index()
        {
            var movieDbLiteContext = _context.AwardWinner
                .Include(a => a.Award)
                .Include(a => a.AwardShowInstance)
                    .ThenInclude(asi => asi.AwardShow)
                .Include(a => a.FilmMember)
                .Include(a => a.Movie);
            return View(await movieDbLiteContext.ToListAsync());
        }

        // GET: AwardWinners/Details/5
        public async Task<IActionResult> Details(int? awardShowInstanceId, int? awardId, long? filmMemberId)
        {
            if (awardShowInstanceId == null || awardId == null || filmMemberId == null)
            {
                return NotFound();
            }

            var awardWinner = await _context.AwardWinner
                .Include(a => a.Award)
                .Include(a => a.AwardShowInstance)
                .Include(a => a.FilmMember)
                .Include(a => a.Movie)
                .FirstOrDefaultAsync(aw => aw.AwardId == awardId && aw.AwardShowInstanceId == awardShowInstanceId
                    && aw.FilmMemberId == filmMemberId);
            if (awardWinner == null)
            {
                return NotFound();
            }

            return View(awardWinner);
        }

        // GET: AwardWinners/Create
        public IActionResult Create()
        {
            CreateAwardIdSelectList();
            ViewData["AwardShowInstanceId"] = new SelectList(_context.AwardShowInstance.Include(f => f.AwardShow).OrderBy(a => a.Year).ThenBy(a => a.AwardShowId), "Id", nameof(AwardShowInstance.FriendlyName));
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
                using (var sqlConn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    await InsertMovieAwardWinnerAsync(sqlConn, awardWinner.AwardShowInstanceId, awardWinner.AwardId, awardWinner.FilmMemberId, awardWinner.MovieId);
                }

                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            CreateAwardIdSelectList();
            ViewData["FilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName", awardWinner.FilmMemberId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", awardWinner.MovieId);
            return View(awardWinner);
        }

        // GET: AwardWinners/Edit/5
        public async Task<IActionResult> Edit(int? awardShowInstanceId, int? awardId, long? filmMemberId)
        {
            if (awardShowInstanceId == null || awardId == null || filmMemberId == null)
            {
                return NotFound();
            }

            AwardWinner awardWinner = await _context.AwardWinner
                .FirstOrDefaultAsync(aw => aw.AwardId == awardId && aw.AwardShowInstanceId == awardShowInstanceId 
                    && aw.FilmMemberId == filmMemberId);
            if (awardWinner == null)
            {
                return NotFound();
            }

            CreateAwardIdSelectList();
            ViewData["AwardShowInstanceId"] = new SelectList(_context.AwardShowInstance, "Id", "Id", awardWinner.AwardShowInstanceId);
            ViewData["FilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName", awardWinner.FilmMemberId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", nameof(Movie.Title), awardWinner.MovieId);
            return View(awardWinner);
        }

        // POST: AwardWinners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("AwardShowInstanceId,AwardId,FilmMemberId,MovieId")] AwardWinner awardWinner)
        {
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
            CreateAwardIdSelectList();
            ViewData["AwardShowInstanceId"] = new SelectList(_context.AwardShowInstance, "Id", "Id", awardWinner.AwardShowInstanceId);
            ViewData["FilmMemberId"] = new SelectList(_context.FilmMember, "Id", "FirstName", awardWinner.FilmMemberId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Description", awardWinner.MovieId);
            return View(awardWinner);
        }

        // GET: AwardWinners/Delete/5
        public async Task<IActionResult> Delete(int? awardShowInstanceId, int? awardId, long? filmMemberId)
        {
            if (awardShowInstanceId == null || awardId == null || filmMemberId == null)
            {
                return NotFound();
            }

            var awardWinner = await _context.AwardWinner
                .Include(a => a.Award)
                .Include(a => a.AwardShowInstance)
                .Include(a => a.FilmMember)
                .Include(a => a.Movie)
                .FirstOrDefaultAsync(aw => aw.AwardId == awardId && aw.AwardShowInstanceId == awardShowInstanceId
                    && aw.FilmMemberId == filmMemberId);
            if (awardWinner == null)
            {
                return NotFound();
            }

            return View(awardWinner);
        }

        // POST: AwardWinners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? awardShowInstanceId, int? awardId, long? filmMemberId)
        {
            if (awardShowInstanceId == null || awardId == null || filmMemberId == null)
            {
                return NotFound();
            }

            var awardWinner = new AwardWinner()
            {
                AwardId = awardId.Value,
                AwardShowInstanceId = awardShowInstanceId.Value,
                FilmMemberId = filmMemberId.Value
            };
            _context.Entry(awardWinner).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AwardWinnerExists(int id)
        {
            return _context.AwardWinner.Any(e => e.AwardShowInstanceId == id);
        }

        private void CreateAwardIdSelectList()
        {
            IEnumerable<AwardViewModel> awards = _mapper.Map<IEnumerable<AwardViewModel>>(_context.Award.Include(m => m.AwardShow));
            ViewData["AwardId"] = new SelectList(awards.OrderBy(aw => aw.AwardShowId), nameof(AwardViewModel.Id), nameof(AwardViewModel.FriendlyName));
        }

        private async Task InsertMovieAwardWinnerAsync(SqlConnection sqlConn, int awardShowInstanceId, int awardId,
            long filmMemberId, long movieId)
        {
            // Specify the stored procedure to call, as well as the connection object
            using var sqlCommand = new SqlCommand("usp_InsertAwardWinner", sqlConn)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Parameterize the arguments (to prevent SQL Injection)
            sqlCommand.Parameters.Add(new SqlParameter("@AwardShowInstanceId", awardShowInstanceId));
            sqlCommand.Parameters.Add(new SqlParameter("@AwardId", awardId));
            sqlCommand.Parameters.Add(new SqlParameter("@FilmMemberId", filmMemberId));
            sqlCommand.Parameters.Add(new SqlParameter("@MovieId", movieId));

            await sqlConn.OpenAsync();

            // Executes the stored procedure here
            await sqlCommand.ExecuteNonQueryAsync();

            await sqlConn.CloseAsync();
        }
    }
}
