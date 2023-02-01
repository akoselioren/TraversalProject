using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TraversalProject.Models;

namespace TraversalProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public LoginController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p)
        {
            AppUser appUser = new AppUser()
            {
                NameSurname = p.NameSurname,
                UserName = p.UserName,
                Email = p.Mail
                // PhoneNumber= p.PhoneNumber
            };
            if (p.Password == p.ComfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, p.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }
        [HttpGet]
        public IActionResult SignIn ()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserRegisterViewModel p)
        {
            //AppUser appUser = new AppUser()
            //{
            //    NameSurname = p.NameSurname,
            //    UserName = p.UserName,
            //    Email = p.Mail
            //    PhoneNumber= p.PhoneNumber
            //};
            //if (p.Password==p.ComfirmPassword)
            //{
            //    var result = await _userManager.CreateAsync(appUser, p.Password);
            //    if (result.Succeeded) 
            //    {
            //        return RedirectToAction("/Default/Index");
            //    }
            //    else 
            //    {
            //        foreach (var item in result.Errors)
            //        {
            //            ModelState.AddModelError("", item.Description);
            //        }
            //    }
            //}
            return View(p);
        }
        
    }
}
