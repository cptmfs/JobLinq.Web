using Microsoft.AspNetCore.Mvc;

namespace JobLinq.Web.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult BlogDetails()
        {
            return View();
        }
    }
}
