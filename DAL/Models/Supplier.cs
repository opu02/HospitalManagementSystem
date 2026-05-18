using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public ICollection<MedicineReport> medicineReport { get; set; }
    }
}
