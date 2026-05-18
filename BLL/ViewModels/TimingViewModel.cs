using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModels
{
    public class TimingViewModel
    {
        public int Id { get; set; }
        public DateTime ScheduleDate { get; set; }

        public int MorningShiftStartTime { get; set; }
        public int MorningShiftEndTime { get; set; }

        public int AfternoonShiftStartTime { get; set; }
        public int AfternoonShiftEndTime { get; set; }

        public int Duration { get; set; }
        public Status Status { get; set; }

        public string DoctorId { get; set; }   // ✅ add

        List<SelectListItem> morningShiftStart = new List<SelectListItem>();
        List<SelectListItem> morningShiftEnd = new List<SelectListItem>();
        List<SelectListItem> AfternoonShiftStart = new List<SelectListItem>();
        List<SelectListItem> AfternoonShiftEnd = new List<SelectListItem>();

        public ApplicationUser Doctor { get; set; }

        public TimingViewModel()
        {
        }

        public TimingViewModel(Timing model)
        {
            Id = model.Id;
            ScheduleDate = model.Date;
            MorningShiftStartTime = model.MorningShiftStartTime;
            MorningShiftEndTime = model.MorningShiftEndTime;
            AfternoonShiftStartTime = model.AfternoonShiftStartTime;
            AfternoonShiftEndTime = model.AfternoonShiftEndTime;
            Duration = model.Duration;
            Status = model.Status;
            DoctorId = model.DoctorId;          
            Doctor = model.Doctor ?? new ApplicationUser { Id = model.DoctorId };
        }

        public Timing ConvertViewModel(TimingViewModel model)
        {
            return new Timing
            {
                Id = model.Id,
                DoctorId = model.DoctorId ?? model.Doctor?.Id,  
                Date = model.ScheduleDate,
                MorningShiftStartTime = model.MorningShiftStartTime,
                MorningShiftEndTime = model.MorningShiftEndTime,
                AfternoonShiftStartTime = model.AfternoonShiftStartTime,
                AfternoonShiftEndTime = model.AfternoonShiftEndTime,
                Duration = model.Duration,
                Status = model.Status,
            };
        }
    }
}