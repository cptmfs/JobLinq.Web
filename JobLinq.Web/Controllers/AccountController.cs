using JobLinq.Web.Models;
using JobLinq.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobLinq.Web.Controllers
{
    public class AccountController : Controller
    {
        private DBJoblinqContext _context;

        public AccountController(DBJoblinqContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserViewModel user)
        {
            var email = _context.Users.Where(i=> i.UserEmail==user.UserEmail);
            var pass= _context.Users.Where(k=>k.UserPassword==user.UserPassword);
            if (email.Any() && pass.Any())
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                return RedirectToAction("Error", "Home");

            }

        }
        public IActionResult Register()
        {
            ViewBag.UserType=new SelectList(new List<UserType>()
            {
                new(){Data="A",Value="Admin"},
                new(){Data="U",Value="User"},
            },"Data","Value");

            return View();
        }
        [HttpPost]
        public IActionResult Register(UserViewModel user)
        {
            var data = new User()
            {
                UserEmail=user.UserEmail,
                UserPassword=user.UserPassword,
                UserType=user.UserType
            };

            _context.Users.Add(data);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}
