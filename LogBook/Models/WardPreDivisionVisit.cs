using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogBook.Models
{
    public class WardPreDivisionVisit : DivisionVisit
    {
        public string WardName { get; set; }
        public DateTime WardTimeArrive { get; set; }
        public string Diagnosis { get; set; }
    }
}
