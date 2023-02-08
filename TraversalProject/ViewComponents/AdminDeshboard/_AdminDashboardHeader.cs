using Microsoft.AspNetCore.Mvc;
namespace TraversalProject.ViewComponents.AdminDeshboard
{
    public class _AdminDashboardHeader : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
