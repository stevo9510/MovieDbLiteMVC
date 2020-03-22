using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace MovieDbLite.Importer
{
    class Program
    {

        private const string TheMovieDbUrl = "https://api.themoviedb.org/3/";


        static void Main(string[] args)
        {
            using var movieDbClient = new HttpClient
            {
                BaseAddress = new Uri(TheMovieDbUrl)
            };
            string apiKey = Environment.GetEnvironmentVariable("TheMovieDbApiKey", EnvironmentVariableTarget.User);
            string apiParam = $"api_key={apiKey}";

            TheMovieDbOrg.Models.SearchResults.Welcome movieResults = GetMovieResults(movieDbClient, apiParam);
            
            long movieId = movieResults.Results[0].Id;
            string movieJson = movieDbClient.GetAsync($"movie/{movieId}?{apiParam}").Result.Content.ReadAsStringAsync().Result;

            var movie = TheMovieDbOrg.Models.Movies.Welcome.FromJson(movieJson);
            string json = TheMovieDbOrg.Models.Movies.Serialize.ToJson(movie);
            var json2 = JsonConvert.DeserializeObject<TheMovieDbOrg.Models.Movies.Welcome>(movieJson);
            
            using var localHttpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44368/")
            };

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = localHttpClient.PostAsync("api/TheMovieDbApi", content).Result;
        }

        private static TheMovieDbOrg.Models.SearchResults.Welcome GetMovieResults(HttpClient httpClient, string apiParam)
        {
            string json = httpClient.GetAsync($"search/movie?{apiParam}&query=fight%20club")
                .Result.Content.ReadAsStringAsync().Result;
            var movieResults = TheMovieDbOrg.Models.SearchResults.Welcome.FromJson(json);
            return movieResults;
        }
    }
}
