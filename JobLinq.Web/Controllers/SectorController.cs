using JobLinq.Web.Models;
using JobLinq.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JobLinq.Web.Controllers
{
    public class SectorController : Controller
    {
        private DBJoblinqContext _context;

        public SectorController(DBJoblinqContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Sectors.ToList();

            return View(data);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(SectorViewModel sector)
        {
            var sectors = new Sector()
            {
                SectorName=sector.SectorName
            };
            _context.Sectors.Add(sectors);
            _context.SaveChanges();
            return RedirectToAction("Index","Sector");
        }
    }
}
