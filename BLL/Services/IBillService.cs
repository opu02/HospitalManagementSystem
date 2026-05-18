using DAL.Models;
namespace BLL.Services
{
    public interface IBillService
    {
        Bill CreateAutoBill(string patientId, int appointmentId);
        IEnumerable<Bill> GetBillsByPatientId(string patientId);
    }
}