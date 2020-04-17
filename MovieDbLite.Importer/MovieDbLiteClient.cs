using MovieDbLite.TheMovieDbOrg.Models.Movies;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbLite.Importer
{
    public class MovieDbLiteApiClient : IDisposable
    {
        // Note: this would normally be in a config file
        private const string MovieDbLiteUrl = "https://localhost:44368/";
        private HttpClient MovieDbLiteHttpClient { get; }

        public MovieDbLiteApiClient()
        {
            MovieDbLiteHttpClient = new HttpClient()
            {
                BaseAddress = new Uri(MovieDbLiteUrl)
            };
        }

        public async Task AddNewMovie(DbOrgMovie movie)
        {
            string json = Serialize.ToJson(movie);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await MovieDbLiteHttpClient.PostAsync("api/TheMovieDbApi", content);
        }

        public void Dispose()
        {
            MovieDbLiteHttpClient?.Dispose();
        }
    }
}
