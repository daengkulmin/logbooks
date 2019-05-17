using LogBook.Models;
using LogBook.Models.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogBook.Data
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options)
        {
            //
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visit> Visits { get; set; }

        public DbSet<DivisionVisit> DivisionVisits { get; set; }
        public DbSet<WardPreDivisionVisit> WardPreDivisionVisits { get; set; }
        public DbSet<OpdDivisionVisit> OpdDivisionVisits { get; set; }

        public DbQuery<PatientDivisionVisitsSummary> vm_PatientDivisionVisitsSummary { get; set; }
    }
}
