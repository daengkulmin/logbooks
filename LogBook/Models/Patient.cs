using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LogBook.Models
{
    public class Patient
    {
        [Key]
        [StringLength(8, MinimumLength = 8)]
        public string HN { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public Sex Sex { get; set; }

        public string Phone { get; set; }

        public ICollection<Visit> Visits { get; set; } = new HashSet<Visit>();
    }
}
