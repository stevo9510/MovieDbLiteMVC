using MovieDbLite.TheMovieDbOrg.Models.Movies;
using MovieDbLite.TheMovieDbOrg.Models.SearchResults;
using System;
using System.Threading.Tasks;

namespace MovieDbLite.Importer
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            var theMovieDbApiClient = new TheMovieDbApiClient();
            var movieDbLiteApiClient = new MovieDbLiteApiClient();    

            string movieName = "The Dark Knight";
            if(args.Length > 0)
            {
                // if passed via CLI, use over default
                movieName = args[0];
            }

            DbOrgMovieResults movieResults = await theMovieDbApiClient.GetMovieResults(movieName);
            if(movieResults.Results.Length == 0)
            {
                throw new Exception("No movie results were found from the search");
            }

            // For these purposes, get the top-most movie id based on the search.  Ignore other results.
            long topMostMovieId = movieResults.Results[0].Id;

            DbOrgMovie movie = await theMovieDbApiClient.GetMovie(topMostMovieId);

            await movieDbLiteApiClient.AddNewMovie(movie);

            theMovieDbApiClient.Dispose();
            movieDbLiteApiClient.Dispose();
        }

    }
}
