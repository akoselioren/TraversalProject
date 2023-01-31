using Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.ViewComponents.Default
{
    public class _StatisticsPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
