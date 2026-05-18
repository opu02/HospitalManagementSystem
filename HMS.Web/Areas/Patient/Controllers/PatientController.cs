using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HMS.Web.Areas.Patient.Controllers
{
    [Area("Patient")]
    [Authorize(Roles = "Patient")]
    public class PatientController : Controller
    {
        private readonly IApplicationUserService _userService;
        private readonly IDoctorService _doctorService;
        private readonly IAppointmentService _appointmentService;
        private readonly IBillService _billService;

        public PatientController(
            IApplicationUserService userService,
            IDoctorService doctorService,
            IAppointmentService appointmentService,
            IBillService billService)
        {
            _userService = userService;
            _doctorService = doctorService;
            _appointmentService = appointmentService;
            _billService = billService;
        }

        public IActionResult Index(string specialist, int pageNumber = 1, int pageSize = 10)
        {
            if (string.IsNullOrWhiteSpace(specialist))
            {
                var doctors = _userService.GetAllDoctors();
                return View(doctors);
            }

            var result = _userService.SearchDoctor(pageNumber, pageSize, specialist);
            return View(result.Data);
        }

        public IActionResult DoctorTiming(string id)
        {
            var timings = _doctorService.GetTimingByDoctorId(id);
            return View(timings);
        }

        public IActionResult BookAppointment(int timingId)
        {
            var timing = _doctorService.GetTimingById(timingId);
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var appointment = new Appoinment
            {
                DoctorId = timing.DoctorId,  
                PatientId = claims.Value,
                CreateDate = DateTime.Now,
                Type = "General",
                Number = Guid.NewGuid().ToString().Substring(0, 8).ToUpper(),
                Description = "Appointment booked by patient"
            };

            _appointmentService.AddAppointment(appointment);
            _billService.CreateAutoBill(claims.Value, appointment.Id);

            return RedirectToAction("MyAppointments");
        }

        public IActionResult CancelAppointment(int id)
        {
            _appointmentService.CancelAppointment(id);
            return RedirectToAction("MyAppointments");
        }

        public IActionResult MyAppointments()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var appointments = _appointmentService.GetAppointmentsByPatientId(claims.Value);
            return View(appointments);
        }

        public IActionResult Bills()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var bills = _billService.GetBillsByPatientId(claims.Value);
            return View(bills);
        }
    }
}