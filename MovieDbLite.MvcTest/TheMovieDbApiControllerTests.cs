using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieDbLite.MVC.Controllers;
using MovieDbLite.MVC.Models;
using MovieDbLite.TheMovieDbOrg.Models.Movies;
using System;
using System.Threading.Tasks;

namespace MovieDbLite.MvcTest
{
    [TestClass]
    public class TheMovieDbApiControllerTests
    {
        [TestMethod]
        public async Task TestInMemoryDatabaseWorksWithSeed()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<MovieDbLiteContext>();
            builder.UseInMemoryDatabase("MovieDbLiteMemory");
            using var dbContext = new MovieDbLiteContext(builder.Options);
            SeedData(dbContext);

            using var testContext = new MovieDbLiteContext(builder.Options);
            int count = await testContext.RestrictionRating.CountAsync();

            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public async Task Post_WillCreateMovieDbLiteMovie_WithBasicDetails()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<MovieDbLiteContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            using var dbContext = new MovieDbLiteContext(builder.Options);
            SeedData(dbContext);

            using var testContext = new MovieDbLiteContext(builder.Options);
            DbOrgMovie dbOrgMovie = CreateObjectWithoutLanguagesAndRestrictionRating();

            var theMovieDbApiController = new TheMovieDbApiController(testContext);
            await theMovieDbApiController.Post(dbOrgMovie);

            using var retrieveContext = new MovieDbLiteContext(builder.Options);

            var movies = await retrieveContext.Movie.ToListAsync();
            Assert.AreEqual(1, movies.Count);
            Movie newMovie = movies[0];

            Assert.AreEqual("Football Movie", newMovie.Title);
        }

        private static DbOrgMovie CreateObjectWithoutLanguagesAndRestrictionRating()
        {
            var dbOrgMovie = new TheMovieDbOrg.Models.Movies.DbOrgMovie()
            {
                Title = "Football Movie",
                Runtime = 150,
                ReleaseDate = new DateTime(2020, 05, 08),
                Genres = new TheMovieDbOrg.Models.Movies.Genre[]
                {
                    new TheMovieDbOrg.Models.Movies.Genre()
                    {
                        Id = 1000,
                        Name = "Thriller"
                    },
                    new TheMovieDbOrg.Models.Movies.Genre()
                    {
                        Id = 1000,
                        Name = "Horror"
                    },
                    new TheMovieDbOrg.Models.Movies.Genre()
                    {
                        Id = 1000,
                        Name = "Action"
                    },
                },
                Overview = "Some people play sports with pigskin to score points",
            };

            return dbOrgMovie;
        }

        private static void SeedData(MovieDbLiteContext dbContext)
        {
            dbContext.RestrictionRating.Add(new RestrictionRating()
            {
                Id = (int)MVC.DbEnum.RestrictionRating.G,
                Code = "G",
                ShortDescription = "G",
                LongDescription = "Don't Matter",
                IsActive = true
            });
            dbContext.RestrictionRating.Add(new RestrictionRating()
            {
                Id = (int)MVC.DbEnum.RestrictionRating.PG,
                Code = "PG",
                ShortDescription = "G",
                LongDescription = "Don't Matter",
                IsActive = true
            });

            dbContext.Genre.Add(new MVC.Models.Genre()
            {
                Id = 1,
                GenreName = "Thriller",
            });

            dbContext.Genre.Add(new MVC.Models.Genre()
            {
                Id = 2,
                GenreName = "Action",
            });

            dbContext.SaveChanges();
        }
    }
}
