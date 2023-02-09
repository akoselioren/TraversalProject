using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TraversalProject.Models;

namespace TraversalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("İndex Sayfası Çağırıldı.");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Privacy sayfası çağırıldı");
            return View();
        }
        public IActionResult Test()
        {
            DateTime date=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _logger.LogInformation(date + " Test sayfası çağırıldı");
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}