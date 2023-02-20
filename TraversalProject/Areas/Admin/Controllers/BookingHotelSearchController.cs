using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using Newtonsoft.Json;
using TraversalProject.Areas.Admin.Models;
using System.Threading.Tasks;

namespace TraversalProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class BookingHotelSearchController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/search?room_number=1&checkout_date=2023-03-05&dest_type=city&dest_id=-1456928&adults_number=2&locale=en-gb&checkin_date=2023-03-04&order_by=popularity&filter_by_currency=EUR&units=metric&page_number=0&children_number=2&include_adjacency=true&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&children_ages=5%2C0"),
                Headers =
    {
        { "X-RapidAPI-Key", "f107f4a1bbmsh113e675a2f67353p1d0905jsnae7b57f4a6af" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var bodyReplace = body.Replace(".", "");
                var values = JsonConvert.DeserializeObject<BookingHotelSearchViewModel>(bodyReplace);
                return View(values.result);
            }
        }


        [HttpGet]
        public IActionResult GetCityDestID()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetCityDestID(string p)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name={p}"),
                Headers =
    {
        { "X-RapidAPI-Key", "f107f4a1bbmsh113e675a2f67353p1d0905jsnae7b57f4a6af" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                return View();
            }
        }
    }
}

