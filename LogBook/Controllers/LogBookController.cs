using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogBook.Data;
using LogBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogBook.Controllers
{
    public class LogBookController : Controller
    {
        private readonly AppDb db;

        public LogBookController(AppDb db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string text)
        {
            var q = from item in db.vm_PatientDivisionVisitsSummary
                    where item.HN.Contains(text) || item.FirstName.Contains(text)
                    select item;

            //return Json(q.ToList());
            return PartialView(q.ToList());
        }

        [HttpGet("LogBook/{an}/WardPre")]
        public IActionResult Details_WardPre(string an)
        {
            var q1 = (from dv in db.WardPreDivisionVisits
                      where dv.VisitAN == an
                      select dv).SingleOrDefault();


            if (q1 == null)
            {
                // TODO: Send custom error message
                return RedirectToAction(nameof(HomeController.Error), nameof(HomeController));
            }

            ViewBag.AN = an;
            return View(q1);

        }

        [Route("LogBook/{an}/WardPre/Create")]
        public IActionResult Create_WardPre(string an)
        {
            ViewBag.AN = an;
            return View();
        }

        [HttpPost("LogBook/{an}/WardPre/Create")]
        public IActionResult Create_WardPre(string an, WardPreDivisionVisit item)
        {
            var visit = db.Visits.Find(an);

            ModelState.Remove(nameof(DivisionVisit.UserName));
            ModelState.Remove(nameof(DivisionVisit.Visit));

            item.UserName = User.Identity.Name ?? "N/A";
            item.Visit = visit;
            item.CreatedDate = DateTime.Now;

            if(ModelState.IsValid)
            {
                visit.DivisionVisits.Add(item);
                db.SaveChanges();

                return RedirectToAction(nameof(Details_WardPre), new { an });
            }

            return View(item);
        }

        [Route("LogBook/{an}/Opd/Create")]
        public IActionResult Create_Opd(string an)
        {
            return View();
        }

        public IActionResult VisitRecord(string id)
        {
            var item = db.vm_PatientDivisionVisitsSummary.Where(x => x.AN == id).SingleOrDefault();

            if (item == null) return Content("");
            return PartialView(item);
        }

        
    }
}