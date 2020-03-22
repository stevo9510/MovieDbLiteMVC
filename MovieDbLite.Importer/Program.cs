using MovieDbLite.TheMovieDbOrg.Models;
using System;
using System.Net.Http;

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

            Welcome movieResults = GetMovieResults(movieDbClient, apiParam);
            
            long movieId = movieResults.Results[0].Id;
            string movieJson = movieDbClient.GetAsync($"movie/{movieId}?{apiParam}").Result.Content.ReadAsStringAsync().Result;

            // Test hitting the 

            //using var localHttpClient = new HttpClient
            //{
            //    BaseAddress = new Uri("https://localhost:44368/")
            //};
            //var testGenre = new Genre()
            //{
            //    Id = 1000,
            //    DisplayName = "Testing",
            //    Description = "Delete this later"
            //};
            ////var usersResultText = localHttpClient.GetAsync("Users").Result.Content.ReadAsStringAsync().Result;
            //string json = JsonConvert.SerializeObject(testGenre);
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            //var result = localHttpClient.PostAsync("Genres/Create", content).Result;
        }

        private static Welcome GetMovieResults(HttpClient httpClient, string apiParam)
        {
            string json = httpClient.GetAsync($"search/movie?{apiParam}&query=fight%20club")
                .Result.Content.ReadAsStringAsync().Result;
            var movieResults = Welcome.FromJson(json);
            return movieResults;
        }
    }
}
