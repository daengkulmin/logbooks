using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LogBook.Models.Queries
{
    [Table("PatientDivisionVisitsSummary")]
    public class PatientDivisionVisitsSummary
    {       
        
        public string HN { get; set; }       
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public Sex Sex { get; set; }
        public string Phone { get; set; }

        public string AN { get; set; } 
        public DateTime AdmissionDate { get; set; } 
        public string Description { get; set; } 
        public Patient Patient { get; set; } 
        public string PatientHN { get; set; }

        public int WardPre { get; set; }
        public int Opd { get; set; }
    }
}
