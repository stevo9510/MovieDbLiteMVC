using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieDbLite.MVC.Models;
using MovieDbLite.TheMovieDbOrg.Models.Movies;
using System;
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

            _context.Add(movie);

            await _context.SaveChangesAsync();
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

    }
}
