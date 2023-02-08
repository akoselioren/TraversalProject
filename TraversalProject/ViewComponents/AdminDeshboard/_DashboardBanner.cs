using Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.ViewComponents.AdminDeshboard
{
    public class _DashboardBanner:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
