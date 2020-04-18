using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieDbLite.MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDbLite.MVC.Controllers
{
    public class FilmMemberDetailsController : Controller
    {
        private readonly MovieDbLiteContext _context;

        public FilmMemberDetailsController(MovieDbLiteContext context)
        {
            _context = context;
        }

        // GET: FilmMemberDetails/Details/5
        public async Task<IActionResult> Details(long id)
        {
            FilmMember filmMember =
                await _context.FilmMember
                    .Include(f => f.MovieCastMember)
                        .ThenInclude(mcm => mcm.Movie)
                    .Include(f => f.MovieCrewMember)
                        .ThenInclude(mcm => mcm.Movie)
                    .Include(f => f.MovieCrewMember)
                        .ThenInclude(mcm => mcm.FilmRole)
                    .Include(f => f.DirectorMovies)
                    .FirstAsync(f => f.Id == id);

            List<VwAwardWinnerInfo> awardWinners = await _context.VwAwardWinnerInfo
                .Where(aw => aw.FilmMemberId == filmMember.Id).ToListAsync();

            List<FilmMemberCredits> allCredits = GetAllCredits(filmMember);

            var filmMemberDetailsViewModel = new FilmMemberDetailsViewModel()
            {
                Prefix = filmMember.Prefix,
                FirstName = filmMember.FirstName,
                MiddleName = filmMember.MiddleName,
                LastName = filmMember.LastName,
                Suffix = filmMember.Suffix,
                PreferredFullName = filmMember.PreferredFullName,
                Gender = filmMember.Gender,
                DateOfBirth = filmMember.DateOfBirth,
                DateOfDeath = filmMember.DateOfDeath,
                Biography = filmMember.Biography,
                Credits = allCredits.ToList(),
                Awards = awardWinners.Select(w => new FilmMemberAwardInfo()
                {
                    AwardName = w.AwardName,
                    MovieTitle = w.Title,
                    ShowName = w.ShowName,
                    Year = w.Year
                }).ToList()
            };

            return View(filmMemberDetailsViewModel);
        }

        private static List<FilmMemberCredits> GetAllCredits(FilmMember filmMember)
        {
            var movieCastCredits =
                filmMember.MovieCastMember.Select(m => new FilmMemberCredits()
                {
                    MovieId = m.MovieId,
                    MovieTitle = m.Movie.Title,
                    FilmRoleId = (short)DbEnum.FilmRole.Actor,
                    RoleName = "Actor",  // not a great way of doing this.
                    CharacterName = m.CharacterName,
                    Year = (short?)m.Movie.ReleaseDate?.Year
                });
            var movieCrewCredits =
                filmMember.MovieCrewMember.Select(m => new FilmMemberCredits()
                {
                    MovieId = m.MovieId,
                    MovieTitle = m.Movie.Title,
                    FilmRoleId = m.FilmRoleId,
                    RoleName = m.FilmRole.RoleName, 
                    CharacterName = null,
                    Year = (short?)m.Movie.ReleaseDate?.Year
                });
            var movieDirectorCredits =
                filmMember.DirectorMovies.Select(m => new FilmMemberCredits()
                {
                    MovieId = m.Id,
                    MovieTitle = m.Title,
                    FilmRoleId = (short)DbEnum.FilmRole.Director,
                    RoleName = "Director",  // not a great way of doing this.
                    CharacterName = null,
                    Year = (short?)m.ReleaseDate?.Year
                });

            var allCredits = movieCrewCredits.Union(movieCastCredits).Union(movieDirectorCredits);
            return allCredits.ToList();
        }
    }
}