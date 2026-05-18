using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class PrescribedMedicine
    {
        public int Id { get; set; }
        public Medicine Medicine { get; set; }
        public PatientReport PatientReport { get; set; }


    }
}
