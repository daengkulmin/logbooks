using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LogBook.Models
{
    public class Visit
    {
        [Key]
        [StringLength(10, MinimumLength = 10)]
        public string AN { get; set; }

        public DateTime AdmissionDate { get; set; }

        public string Description { get; set; }

        [Required]
        public Patient Patient { get; set; }

        [ForeignKey(nameof(Patient))]
        public string PatientHN { get; set; }

        public ICollection<DivisionVisit> DivisionVisits { get; set; }
            = new HashSet<DivisionVisit>();
    }
}
