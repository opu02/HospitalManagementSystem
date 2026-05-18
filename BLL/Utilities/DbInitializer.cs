using DAL.Models;
using DAL.Repos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Utilities
{
    public class DbInitializer : IDbInitializer
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;

        public DbInitializer(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }

                if (!_roleManager.RoleExistsAsync(Roles.Admin).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(Roles.Admin)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(Roles.Patient)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(Roles.Doctor)).GetAwaiter().GetResult();

                    _userManager.CreateAsync(new ApplicationUser
                    {
                        UserName = "Jahid",
                        Email = "jahid@xyz.com",
                         EmailConfirmed = true
                    }, "opu@246").GetAwaiter().GetResult();

                    var Appuser = _context.ApplicationUsers.FirstOrDefault(x => x.Email == "jahid@xyz.com");
                    if (Appuser != null)
                    {
                        _userManager.AddToRoleAsync(Appuser, Roles.Admin).GetAwaiter().GetResult();
                    }
                }

                // Insurance seed
                if (!_context.Insurances.Any())
                {
                    _context.Insurances.Add(new Insurance
                    {
                        PolicyNumber = "P-1001",
                        StartDate = "2026-01-01",
                        EndDate = "2027-01-01"
                    });
                    _context.SaveChanges();
                }

                if (!_context.HospitalInfos.Any())
                {
                    _context.HospitalInfos.AddRange(
                        new HospitalInfo { Name = "Apex", Type = "Multi Speciality", City = "Dhaka", PinCode = "333045", Country = "Bangladesh" },
                        new HospitalInfo { Name = "Apollo Hospital", Type = "Multi Speciality", City = "Chittagong", PinCode = "12345", Country = "Bangladesh" },
                        new HospitalInfo { Name = "AIIMS", Type = "Government", City = "Rajshahi", PinCode = "11001", Country = "Bangladesh" },
                        new HospitalInfo { Name = "Fortis Hospital", Type = "Private", City = "Khulna", PinCode = "70001", Country = "Bangladesh" },
                        new HospitalInfo { Name = "Max Hospital", Type = "Private", City = "Barishal", PinCode = "60001", Country = "Bangladesh" }
                    );
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}