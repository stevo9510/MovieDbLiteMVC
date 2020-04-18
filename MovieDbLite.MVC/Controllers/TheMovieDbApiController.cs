using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MovieDbLite.MVC.Models;
using MovieDbLite.TheMovieDbOrg.Models.Movies;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDbLite.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheMovieDbApiController : ControllerBase
    {
        private readonly MovieDbLiteContext _context;

        public TheMovieDbApiController(MovieDbLiteContext context)
        {
            _context = context;
        }

        // POST: api/TheMovieDbApi
        [HttpPost]
        public async Task Post([FromBody] DbOrgMovie dbOrgMovie)
        {
            var movie = new Movie();

            // Set basic details (easy)
            movie.Title = dbOrgMovie.Title;
            movie.Description = dbOrgMovie.Overview.Substring(0, Math.Min(dbOrgMovie.Overview.Length, 500));
            movie.DurationInMinutes = (int)dbOrgMovie.Runtime;
            movie.ReleaseDate = dbOrgMovie.ReleaseDate.DateTime;

            // Set Restriction Rating.  Use certification of first US Release in TheMovieDbOrg results.
            movie.RestrictionRatingId = await GetRestrictionRating(dbOrgMovie);

            // Set Genre/Language lists by reference
            await SetMovieGenres(dbOrgMovie, movie);
            await SetMovieLanguages(dbOrgMovie, movie);

            #region Insert With Stored Procedure

            using var sqlConn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString);
            await InsertMovieWithStoredProcedureAsync(sqlConn, movie);

            #endregion

            #region Insert with Entity Framework (Commented out)

            //_context.Add(movie);
            //await _context.SaveChangesAsync();

            #endregion
        }

        private async Task<short?> GetRestrictionRating(DbOrgMovie dbOrgMovie)
        {
            string restrictionRatingCode =
                dbOrgMovie.Releases.Countries.Where(c => c.Iso3166_1 == "US") // Get US releases
                    .OrderBy(c => c.ReleaseDate) // Get First Release (Assumes it is Theatrical Release)
                    .Select(r => r.Certification)
                    .FirstOrDefault();

            RestrictionRating restrictionRating = await _context.RestrictionRating.Where(r => r.Code == restrictionRatingCode).FirstOrDefaultAsync();

            return restrictionRating?.Id;
        }

        private async Task SetMovieGenres(DbOrgMovie dbOrgMovie, Movie movie)
        {
            // match genre names between two databases to get ones that exist in both
            var dbOrgMovieGenreNames = dbOrgMovie.Genres.Select(g => g.Name).ToList();
            var matchedGenres = _context.Genre.Where(genre => dbOrgMovieGenreNames.Contains(genre.GenreName));

            foreach (Models.Genre genre in await matchedGenres.ToListAsync())
            {
                movie.MovieGenre.Add(new MovieGenre()
                {
                    GenreId = genre.Id
                });
            }
        }

        private async Task SetMovieLanguages(DbOrgMovie dbOrgMovie, Movie movie)
        {
            // match languages iso codes between two databases to get ones that exist in both
            var dbOrgLanguages = dbOrgMovie.SpokenLanguages.Select(l => l.Iso639_1).ToList();
            var matchedLanguages = _context.Language.Where(l => dbOrgLanguages.Contains(l.LanguageIsoCode));

            foreach (var language in await matchedLanguages.ToListAsync())
            {
                movie.MovieLanguage.Add(new MovieLanguage()
                {
                    LanguageIsoCode = language.LanguageIsoCode
                });
            }
        }

        private async Task<long> InsertMovieWithStoredProcedureAsync(SqlConnection sqlConn, Movie movie)
        {
            // Specify the stored procedure to call, as well as the connection object
            using var sqlCommand = new SqlCommand("usp_InsertMovieDetails", sqlConn)
            {
                CommandType = CommandType.StoredProcedure
            };

            DataTable dtLanguages = ToDataTable("LanguageIsoCode", movie.MovieLanguage.Select(s => s.LanguageIsoCode));
            DataTable dtGenres = ToDataTable("GenreId", movie.MovieGenre.Select(s => s.GenreId));

            // Parameterize the arguments (to prevent SQL Injection)
            sqlCommand.Parameters.AddWithValue("@Title", movie.Title);
            sqlCommand.Parameters.AddWithValue("@Description", movie.Description);
            sqlCommand.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate ?? SqlDateTime.Null);
            sqlCommand.Parameters.AddWithValue("@RestrictionRatingId", movie.RestrictionRatingId ?? SqlInt16.Null);
            sqlCommand.Parameters.AddWithValue("@DirectorFilmMemberId", movie.DirectorFilmMemberId ?? SqlInt64.Null);
            sqlCommand.Parameters.AddWithValue("@DurationInMinutes", movie.DurationInMinutes ?? SqlInt32.Null);
            sqlCommand.Parameters.Add(new SqlParameter("@LanguageIsoCodes", dtLanguages)
            {
                SqlDbType = SqlDbType.Structured
            });
            sqlCommand.Parameters.Add(new SqlParameter("@GenreIds", dtGenres)
            {
                SqlDbType = SqlDbType.Structured
            });
            var movieIdOutputParam = new SqlParameter("@MovieId", SqlDbType.BigInt)
            {
                Direction = ParameterDirection.Output
            };
            sqlCommand.Parameters.Add(movieIdOutputParam);

            await sqlConn.OpenAsync();

            // Executes the stored procedure here
            await sqlCommand.ExecuteNonQueryAsync();

            await sqlConn.CloseAsync();

            return long.Parse(movieIdOutputParam.Value.ToString());
        }

        private static DataTable ToDataTable<T>(string columnName, IEnumerable<T> coll)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(columnName, typeof(T));

            foreach (T item in coll)
            {
                DataRow dr = dt.NewRow();
                dr[columnName] = item;
                dt.Rows.Add(dr);
            }

            return dt;
        }

    }
}
