using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Appoinment
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }

        public string DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public ApplicationUser Doctor { get; set; }

        public string PatientId { get; set; }
        [ForeignKey("PatientId")]
        public ApplicationUser Patient { get; set; }
    }
}