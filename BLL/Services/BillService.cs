using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class BillService : IBillService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BillService(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

        public Bill CreateAutoBill(string patientId, int appointmentId)
        {
            var insurance = _unitOfWork.GenericRepository<Insurance>().GetAll().FirstOrDefault();
            if (insurance == null) throw new InvalidOperationException("At least one Insurance is required");

            var patient = _unitOfWork.GenericRepository<ApplicationUser>().GetById(patientId);
            if (patient == null) throw new InvalidOperationException("Patient not found");

            int doctorCharge = 500;
            decimal totalBill = doctorCharge;

            var bill = new Bill
            {
                BillNumber = (int)(DateTime.UtcNow.Ticks % int.MaxValue),
                Patient = patient,
                Insurance = insurance,
                DoctorCharge = doctorCharge,
                TotalBill = totalBill,
                AppoinmentId = appointmentId
            };

            _unitOfWork.GenericRepository<Bill>().Add(bill);
            _unitOfWork.Save();
            return bill;
        }

        public IEnumerable<Bill> GetBillsByPatientId(string patientId)
        {
            return _unitOfWork.GenericRepository<Bill>()
                .GetAll(b => b.Patient.Id == patientId, null, "Patient,Insurance,Appoinment")
                .ToList();
        }
    }
}