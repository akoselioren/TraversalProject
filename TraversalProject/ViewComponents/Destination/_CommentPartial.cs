using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.ViewComponents.Destination
{
    public class _CommentPartial:ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke(int id)
        {
            var values =commentManager.TGetDestinationById(id);
            return View(values);
        }
    }
}
