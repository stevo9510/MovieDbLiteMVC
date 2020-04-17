using MovieDbLite.TheMovieDbOrg.Models.Movies;
using MovieDbLite.TheMovieDbOrg.Models.SearchResults;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieDbLite.Importer
{
    public class TheMovieDbApiClient : IDisposable
    {
        // Note: this would normally be in a config file
        private const string TheMovieDbUrl = "https://api.themoviedb.org/3/"; 
        private HttpClient MovieDbHttpClient { get; }
        private string ApiKey { get; } = Environment.GetEnvironmentVariable("TheMovieDbApiKey", EnvironmentVariableTarget.User);
        private string ApiKeyParam { get; }

        public TheMovieDbApiClient()
        {
            MovieDbHttpClient = new HttpClient()
            {
                BaseAddress = new Uri(TheMovieDbUrl)
            };

            ApiKeyParam = $"api_key={ApiKey}";
        }

        public async Task<DbOrgMovieResults> GetMovieResults(string queryString)
        {
            string escapedQuery = Uri.EscapeUriString(queryString);
            HttpResponseMessage response = await MovieDbHttpClient.GetAsync($"search/movie?{ApiKeyParam}&query={escapedQuery}");
            string json = await response.Content.ReadAsStringAsync();
            DbOrgMovieResults movieResults = DbOrgMovieResults.FromJson(json);
            return movieResults;
        }

        public async Task<DbOrgMovie> GetMovie(long movieId)
        {
            HttpResponseMessage response = await MovieDbHttpClient.GetAsync($"movie/{movieId}?{ApiKeyParam}&append_to_response=releases");
            string json = await response.Content.ReadAsStringAsync();
            DbOrgMovie movie = DbOrgMovie.FromJson(json);
            return movie;
        }

        public void Dispose()
        {
            MovieDbHttpClient?.Dispose();
        }
    }
}
