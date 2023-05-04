using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobLinq.Web.Models;
using Newtonsoft.Json.Linq;
using JobLinq.Web.ViewModels;

namespace JobLinq.Web.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly DBJoblinqContext _context;

        public CandidatesController(DBJoblinqContext context)
        {
            _context = context;
        }

        // GET: Candidates
        public async Task<IActionResult> Index()
        {
            //if (_context.Candidates == null)
            //{
            //    return Problem("Entity set 'DBJoblinqContext.Candidates' is null.");
            //}

            //var city = await _context.Candidates
            //    .OrderByDescending(p => p.CandidateId)
            //    .Include(c => c.City)
            //    .ToListAsync();

            //return View(city);


            //var city = _context.Candidates
            //   .OrderByDescending(p => p.CandidateId)
            //   .Select(x => new
            //   {
            //       x.UserId,
            //       x.Fname,
            //       x.Lname,
            //       x.BirthDate,
            //       x.CityId,
            //       x.City.CityName,
            //       x.Gsmno
            //   })
            //   .ToList();
            //return View(city);

            //var city =  _context.Candidates.OrderByDescending(p => p.CandidateId).Select(x =>new
            //{
            //    x.UserId,
            //    x.Fname,
            //    x.Lname,
            //    x.BirthDate,
            //    x.City.CityName,
            //    x.Gsmno
            //});

            var city =  _context.Candidates
                .OrderByDescending(p => p.CandidateId)
                .Include(c => c.City);
            return _context.Candidates != null ?
                        View(await city.ToListAsync()) :
                        Problem("Entity set 'DBJoblinqContext.Candidates'  is null.");

        }
        // GET: Candidates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Candidates == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates
                .FirstOrDefaultAsync(m => m.CandidateId == id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // GET: Candidates/Create
        public IActionResult Create()
        {
            //ViewBag.city = new SelectList(new List<City>()
            //{
            //    new(){CityName="İstanbul",CityId=1},
            //    new(){CityName="Ankara",CityId=2},
            //    new(){CityName="İzmir",CityId=3},
            //    new(){CityName="Kastamonu",CityId=4},
            //}, "CityId", "CityName");

            //Bu yöntem ile veritabanından verileri dropdownlist içerisine doldurmayı başarıyoruz..
            List<SelectListItem> citylist = (from cl in _context.Cities.ToList()
                                             select new SelectListItem
                                             {
                                                Value=cl.CityId.ToString(),
                                                Text=cl.CityName
                                             }).OrderBy(i=> i.Text).ToList();
            ViewBag.citylist= citylist;
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CandidateId,UserId,Fname,Lname,BirthDate,CityId,Gsmno")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidate);
        }

        // GET: Candidates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Candidates == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }


            List<SelectListItem> citylist = (from cl in _context.Cities.ToList()
                                             select new SelectListItem
                                             {
                                                 Value = cl.CityId.ToString(),
                                                 Text = cl.CityName
                                             }).OrderBy(i => i.Text).ToList();
            ViewBag.citylist = citylist;
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CandidateId,UserId,Fname,Lname,BirthDate,CityId,Gsmno")] Candidate candidate)
        {
            if (id != candidate.CandidateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidateExists(candidate.CandidateId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Candidates == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates
                .FirstOrDefaultAsync(m => m.CandidateId == id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Candidates == null)
            {
                return Problem("Entity set 'DBJoblinqContext.Candidates'  is null.");
            }
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate != null)
            {
                _context.Candidates.Remove(candidate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidateExists(int id)
        {
          return (_context.Candidates?.Any(e => e.CandidateId == id)).GetValueOrDefault();
        }
    }
}
