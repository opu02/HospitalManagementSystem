using BLL.Utilities;
using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public interface IDoctorService
    {
        PagedResult<TimingViewModel> GetAll(int pageNumber, int pageSize);
        IEnumerable<TimingViewModel> GetAll();
        IEnumerable<TimingViewModel> GetTimingByDoctorId(string doctorId);

        TimingViewModel GetTimingById(int TimingId);

        void UpdateTiming(TimingViewModel timing);
        void AddTiming(TimingViewModel timing);
        void DeleteTiming(int TimingId);
    }
}
