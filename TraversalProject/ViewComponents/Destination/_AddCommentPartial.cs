using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.ViewComponents.Destination
{
    public class _AddCommentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
