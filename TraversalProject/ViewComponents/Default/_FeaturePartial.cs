using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.ViewComponents.Default
{
    public class _FeaturePartial:ViewComponent
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
        public IViewComponentResult Invoke()
        {
            //ViewBag.image1=
            return View();
        }
    }
}
