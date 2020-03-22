using Microsoft.AspNetCore.Mvc;
using MovieDbLite.MVC.Models;
using System;
using System.Collections.Generic;
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

        // GET: api/TheMovieDbApi
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TheMovieDbApi/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TheMovieDbApi
        [HttpPost]
        public async Task Post([FromBody] MovieDbLite.TheMovieDbOrg.Models.Movies.Welcome movieDbMovie)
        {
            var movie = new Movie();
            movie.Title = movieDbMovie.Title;
            movie.LanguageId = 1;
            movie.Description = movieDbMovie.Overview.Substring(0, Math.Min(movieDbMovie.Overview.Length, 500));
            movie.DurationInMinutes = (int)movieDbMovie.Runtime;
            movie.DirectorFilmMemberId = 3; // TODO: This will need to be looked up later...
            movie.ReleaseDate = movieDbMovie.ReleaseDate.DateTime;

            _context.Add(movie);
            
            await _context.SaveChangesAsync();
        }

        // PUT: api/TheMovieDbApi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
