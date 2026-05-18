using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string name { get; set; }
        public Gender Gender { get; set; }
        public string Nationality { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
        public DateTime DOB { get; set; }
        public string Specialist { get; set; }

        public bool IsDoctor { get; set; }

        public string PictureUri { get; set; }

        [NotMapped]
        public Department Department { get; set; }
        [NotMapped]

        public ICollection<Appoinment> Appoinments { get; set; }
        [NotMapped]
        public ICollection<Payroll> Payrolls { get; set; }
        [NotMapped]

        public ICollection<PatientReport> PatientReports { get; set; }
        
    }
}

    namespace DAL
    {
        public enum Gender
        {
            Male, Female, Other
        }
    }