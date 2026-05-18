using DAL.Models;

namespace BLL.Services
{
    public interface IAppointmentService
    {
        void AddAppointment(Appoinment appointment);
        void CancelAppointment(int id);
        IEnumerable<Appoinment> GetAppointmentsByPatientId(string patientId);
    }
}