using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.Areas.Member.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
