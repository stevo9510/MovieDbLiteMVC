using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MovieDbLite.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieDbLite.MVC.Controllers
{
    public class MovieDetailsController : Controller
    {
        private readonly MovieDbLiteContext _context;

        public MovieDetailsController(MovieDbLiteContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Details(long id)
        {
            MovieDetailsViewModel viewModel = await GetMovieAsync(m => m.Id == id);
            return View("Search", viewModel);
        }

        // GET: MovieDetails/Search/{movieTitle}
        public async Task<IActionResult> Search(string movieTitle)
        {
            MovieDetailsViewModel viewModel = await GetMovieAsync(m => m.Title == movieTitle);
            return View(viewModel);
        }

        private async Task<MovieDetailsViewModel> GetMovieAsync(Expression<Func<Movie, bool>> movieSearchPredicate)
        {
            // TODO: Make this support more than one search result in future, and showing results page
            Movie movieGeneralDetails = await _context.Movie
                .Include(m => m.DirectorFilmMember)
                .Include(m => m.RestrictionRating)
                .Include(m => m.MovieGenre)
                .ThenInclude(mg => mg.Genre)
                .Include(m => m.MovieLanguage)
                .ThenInclude(ml => ml.LanguageIsoCodeNavigation)
                .FirstOrDefaultAsync(movieSearchPredicate);
            using var sqlConn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString);
            DataTable dtMovieCastAndCrew = GetMovieCastAndCrew(sqlConn, movieGeneralDetails.Id);
            List<MovieCastMemberDetail> castMembers = GetCastMembers(dtMovieCastAndCrew);
            List<MovieCrewMemberDetail> crewMembers = GetCrewMembers(dtMovieCastAndCrew);

            List<VwAwardWinnerInfo> awards = await _context.VwAwardWinnerInfo.Where(w => w.MovieId == movieGeneralDetails.Id).ToListAsync();
            List<AwardInfo> awardInformation = awards.Select(a => new AwardInfo()
            {
                AwardName = a.AwardName,
                PreferredFullName = a.PreferredFullName,
                ShowName = a.ShowName,
                Year = a.Year
            }).ToList();

            var viewModel = new MovieDetailsViewModel()
            {
                Title = movieGeneralDetails.Title,
                Description = movieGeneralDetails.Description,
                ReleaseDate = movieGeneralDetails.ReleaseDate,
                RestrictionRating = movieGeneralDetails.RestrictionRating?.Code,
                DirectorName = movieGeneralDetails.DirectorFilmMember?.PreferredFullName,
                Duration = $"{movieGeneralDetails.DurationInMinutes} mins",
                AverageUserRating = movieGeneralDetails.AverageUserRating,
                Languages = string.Join(',', movieGeneralDetails.MovieLanguage.Select(l => l.LanguageIsoCodeNavigation.LanguageName)),
                Genres = string.Join(',', movieGeneralDetails.MovieGenre.Select(g => g.Genre.GenreName)),
                Image = null,
                MovieCastMembers = castMembers,
                MovieCrewMembers = crewMembers,
                AwardDetails = awardInformation,
            };

            return viewModel;
        }

        public DataTable GetMovieCastAndCrew(SqlConnection sqlConn, long movieId)
        {
            string command = @"
            SELECT FilmMember.PreferredFullName,
	            FilmRole.RoleName,
	            mFilmMember.CharacterName,
                FilmRole.Id as FilmRoleId,
                FilmMember.Id as FilmMemberId,
                mFilmMember.Sequence
            FROM tvf_GetAllMovieFilmMembers(@MovieId) mFilmMember
            INNER JOIN FilmMember ON FilmMember.Id = mFilmMember.FilmMemberId
            INNER JOIN FilmRole ON FilmRole.Id = mFilmMember.FilmRoleId
            ORDER BY 
	            -- List Director First
	            CASE WHEN mFilmMember.FilmRoleId = 3 -- @FilmRoleId_Director 
		            THEN 0
		            ELSE 1
	            END,
	            -- Prioritize Actors secondly
	            CASE WHEN mFilmMember.FilmRoleId = 2 -- @FilmMemberId_Actor
		            THEN 0
		            ELSE 1
	            END,
	            -- Order Actors by Sequence
	            mFilmMember.Sequence,
	            -- Simply order by Role Id after this
	            mFilmMember.FilmRoleId
            ";

            using SqlCommand sqlCommand = new SqlCommand(command, sqlConn);
            sqlCommand.Parameters.AddWithValue("@MovieId", movieId);
            using SqlDataAdapter myDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }

        private static List<MovieCastMemberDetail> GetCastMembers(DataTable dtCastAndCrew)
        {
            var castMembers = dtCastAndCrew.AsEnumerable()
                .Where(dr => dr.Field<short>("FilmRoleId") == (short)DbEnum.FilmRole.Actor);
            var movieCastMemberDetails = new List<MovieCastMemberDetail>();

            foreach (DataRow dr in castMembers)
            {
                movieCastMemberDetails.Add(new MovieCastMemberDetail()
                {
                    FilmMemberId = dr.Field<long>("FilmMemberId"),
                    Name = dr.Field<string>("PreferredFullName"),
                    CharacterName = dr.Field<string>("CharacterName"),
                    Sequence = dr.Field<int?>("Sequence")
                });
            }

            return movieCastMemberDetails;
        }

        private List<MovieCrewMemberDetail> GetCrewMembers(DataTable dtCastAndCrew)
        {
            var crewMembers = dtCastAndCrew.AsEnumerable()
                .Where(dr => dr.Field<short>("FilmRoleId") != (short)DbEnum.FilmRole.Actor
                    && dr.Field<short>("FilmRoleId") != (short)DbEnum.FilmRole.Director);
            var movieCrewMemberDetails = new List<MovieCrewMemberDetail>();

            foreach (DataRow dr in crewMembers)
            {
                movieCrewMemberDetails.Add(new MovieCrewMemberDetail()
                {
                    FilmMemberId = dr.Field<long>("FilmMemberId"),
                    Name = dr.Field<string>("PreferredFullName"),
                    RoleName = dr.Field<string>("RoleName"),
                });
            }

            return movieCrewMemberDetails;
        }

    }
}