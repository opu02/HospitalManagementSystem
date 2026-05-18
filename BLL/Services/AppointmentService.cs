using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class AppointmentService : IAppointmentService
    {
        private IUnitOfWork _unitOfWork;

        public AppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddAppointment(Appoinment appointment)
        {
            _unitOfWork.GenericRepository<Appoinment>().Add(appointment);
            _unitOfWork.Save();
        }

        
        public void CancelAppointment(int id)
        {
            var bill = _unitOfWork.GenericRepository<Bill>()
                .GetAll(b => b.AppoinmentId == id)
                .FirstOrDefault();

            if (bill != null)
                _unitOfWork.GenericRepository<Bill>().Delete(bill);

            var appointment = _unitOfWork.GenericRepository<Appoinment>().GetById(id);
            _unitOfWork.GenericRepository<Appoinment>().Delete(appointment);
            _unitOfWork.Save();
        }

        public IEnumerable<Appoinment> GetAppointmentsByPatientId(string patientId)
        {
            return _unitOfWork.GenericRepository<Appoinment>().GetAll(x => x.PatientId == patientId, null,"Doctor").ToList();
        }
    }
}