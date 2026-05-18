using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Repos
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Appoinment> Appoinments { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<HospitalInfo> HospitalInfos { get; set; }

        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicineReport> MedicineReports { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<PrescribedMedicine> PrescribedMedicines { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<TestPrice> TestPrices { get; set; }

        public DbSet<Timing> Timings { get; set; }
        public DbSet<PatientReport> PatientReports { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Appoinment
            builder.Entity<Appoinment>()
                .HasOne(a => a.Doctor)
                .WithMany()
                .HasForeignKey("DoctorId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Appoinment>()
                .HasOne(a => a.Patient)
                .WithMany(u => u.Appoinments)
                .HasForeignKey("PatientId")
                .OnDelete(DeleteBehavior.Restrict);

            // PatientReport
            builder.Entity<PatientReport>()
                .HasOne(a => a.Doctor)
                .WithMany()
                .HasForeignKey("DoctorId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PatientReport>()
                .HasOne(a => a.Patient)
                .WithMany()
                .HasForeignKey("PatientId")
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}