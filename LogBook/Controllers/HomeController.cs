using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LogBook.Models;
using LogBook.Data;

namespace LogBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDb db;

        public HomeController(AppDb db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            //AddPatient();
            //AddVisit();
            return View();
        }

        private void AddVisit()
        {
            var patients = db.Patients.ToList();
            foreach (var item in patients)
            {
                var visit = new Visit();
                visit.AdmissionDate = DateTime.Now;
                visit.AN = item.HN + "00";
                visit.PatientHN = item.HN;
                db.Visits.Add(visit);
            }
            db.SaveChanges();
        }

        private void AddPatient()
        {
            for (int i = 0; i < 10; i++)
            {
                var p = new Patient();
                p.HN = $"11222{DateTime.Now.Millisecond + i:000}";
                p.FirstName = "First";
                p.LastName = "last";
                p.Birthdate = DateTime.Today.AddYears(-40);
                p.Sex = Sex.Male;
                p.Phone = "999";

                db.Add(p);
            }
           
            db.SaveChanges();


        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
