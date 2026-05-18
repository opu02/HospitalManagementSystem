using DAL.Repos;
using DAL.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PayrollsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PayrollsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var data = _context.Payrolls.Include(p => p.Employee);
            return View(await data.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var payroll = await _context.Payrolls
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (payroll == null) return NotFound();
            return View(payroll);
        }

        public async Task<IActionResult> Create()
        {
            var doctors = await _userManager.GetUsersInRoleAsync("Doctor");
            ViewData["EmployeeId"] = new SelectList(doctors, "Id", "Email");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Payroll payroll)
        {
            if (!ModelState.IsValid)
            {
                var doctors = await _userManager.GetUsersInRoleAsync("Doctor");
                ViewData["EmployeeId"] = new SelectList(doctors, "Id", "Email", payroll.EmployeeId);
                return View(payroll);
            }

            _context.Add(payroll);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var payroll = await _context.Payrolls.FindAsync(id);
            if (payroll == null) return NotFound();

            var doctors = await _userManager.GetUsersInRoleAsync("Doctor");
            ViewData["EmployeeId"] = new SelectList(doctors, "Id", "Email", payroll.EmployeeId);
            return View(payroll);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Payroll payroll)
        {
            if (id != payroll.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                var doctors = await _userManager.GetUsersInRoleAsync("Doctor");
                ViewData["EmployeeId"] = new SelectList(doctors, "Id", "Email", payroll.EmployeeId);
                return View(payroll);
            }

            _context.Update(payroll);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var payroll = await _context.Payrolls
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (payroll == null) return NotFound();
            return View(payroll);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payroll = await _context.Payrolls.FindAsync(id);
            if (payroll != null) _context.Payrolls.Remove(payroll);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}