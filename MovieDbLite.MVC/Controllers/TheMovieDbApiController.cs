using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieDbLite.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheMovieDbApiController : ControllerBase
    {
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
        public void Post([FromBody] string value)
        {
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
