using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using TraversalProject.Areas.Admin.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TraversalProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class ApiExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<BookingExchangeViewModel2> bookingExchangeViewModels=new List<BookingExchangeViewModel2>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?locale=tr&currency=TRY"),
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
                Console.WriteLine(body);
                var values = JsonConvert.DeserializeObject<BookingExchangeViewModel2>(body);
                return View(values.exchange_rates);
            }
            
        }
    }
}
