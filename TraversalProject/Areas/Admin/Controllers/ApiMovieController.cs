using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using TraversalProject.Areas.Admin.Models;
using Newtonsoft.Json;

namespace TraversalProject.Areas.Admin.Controllers
{
    public class ApiMovieController : Controller
    {
        [AllowAnonymous]
        [Area("Admin")]
        public async Task<IActionResult> Index()
        {
            List<ApiMovieViewModel> apiMovies= new List<ApiMovieViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "f107f4a1bbmsh113e675a2f67353p1d0905jsnae7b57f4a6af" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                apiMovies=JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
            }
            return View(apiMovies);
        }
    }
}
