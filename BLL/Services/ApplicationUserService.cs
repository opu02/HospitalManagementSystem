using BLL.Utilities;
using BLL.ViewModels;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private IUnitOfWork _unitOfWork;

        public ApplicationUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PagedResult<ApplicationUserViewModel> GetAll(int PageNumber, int PageSize)
        {
            var vm = new ApplicationUserViewModel();
            int totalCount;
            List<ApplicationUserViewModel> vmList = new List<ApplicationUserViewModel>();
            try
            {
                int ExcludeRecords = (PageSize * PageNumber) - PageSize;

                var modelList = _unitOfWork.GenericRepository<ApplicationUser>().GetAll()
                    .Skip(ExcludeRecords).Take(PageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<ApplicationUser>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }

            var result = new PagedResult<ApplicationUserViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = PageNumber,
                PageSize = PageSize
            };
            return result;
        }

        public PagedResult<ApplicationUserViewModel> GetAllDoctor(int PageNumber, int PageSize)
        {
            var vm = new ApplicationUserViewModel();
            int totalCount;
            List<ApplicationUserViewModel> vmList = new List<ApplicationUserViewModel>();
            try
            {
                int ExcludeRecords = (PageSize * PageNumber) - PageSize;

                var modelList = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x=>x.IsDoctor==true)
                    .Skip(ExcludeRecords).Take(PageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x=>x.IsDoctor==true).ToList().Count;

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }

            var result = new PagedResult<ApplicationUserViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = PageNumber,
                PageSize = PageSize
            };
            return result;
        }

        public PagedResult<ApplicationUserViewModel> GetAllPatient(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        public PagedResult<ApplicationUserViewModel> SearchDoctor(int PageNumber, int PageSize, string Spicility = null)
        {
            int totalCount;
            List<ApplicationUserViewModel> vmList = new List<ApplicationUserViewModel>();

            int ExcludeRecords = (PageSize * PageNumber) - PageSize;

            var query = _unitOfWork.GenericRepository<ApplicationUser>()
                .GetAll(x => x.IsDoctor == true);

            if (!string.IsNullOrWhiteSpace(Spicility))
            {
                query = query.Where(x => x.Specialist != null && x.Specialist.Contains(Spicility));
            }

            var modelList = query.Skip(ExcludeRecords).Take(PageSize).ToList();
            totalCount = query.Count();

            vmList = ConvertModelToViewModelList(modelList);

            return new PagedResult<ApplicationUserViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = PageNumber,
                PageSize = PageSize
            };
        }

        private List<ApplicationUserViewModel> ConvertModelToViewModelList(List<ApplicationUser> modelList)
        {
            return modelList.Select(x => new ApplicationUserViewModel(x)).ToList();
        }

        public IEnumerable<ApplicationUserViewModel> GetAllDoctors()
        {
            var doctors = _unitOfWork.GenericRepository<ApplicationUser>()
                .GetAll(x => x.IsDoctor == true).ToList();
            return ConvertModelToViewModelList(doctors);
        }

        public ApplicationUserViewModel GetById(string id)
        {
            var user = _unitOfWork.GenericRepository<ApplicationUser>().GetAll()
                .FirstOrDefault(x => x.Id == id);
            return new ApplicationUserViewModel(user);
        }

        public void Update(ApplicationUserViewModel vm)
        {
            var user = _unitOfWork.GenericRepository<ApplicationUser>().GetAll()
                .FirstOrDefault(x => x.Id == vm.Id);
            user.name = vm.name;
            user.City = vm.City;
            user.Gender = vm.Gender;
            user.IsDoctor = vm.IsDoctor;
            user.Specialist = vm.Specialist;
            user.Email = vm.Email;
            user.UserName = vm.UserName;
            _unitOfWork.GenericRepository<ApplicationUser>().Update(user);
            _unitOfWork.Save();
        }

        public void Delete(string id)
        {
            var timings = _unitOfWork.GenericRepository<Timing>().GetAll()
                .Where(x => x.DoctorId == id).ToList();
            foreach (var timing in timings)
            {
                _unitOfWork.GenericRepository<Timing>().Delete(timing);
            }

            var appointments = _unitOfWork.GenericRepository<Appoinment>().GetAll()
                .Where(x => x.DoctorId == id || x.PatientId == id).ToList();
            foreach (var appointment in appointments)
            {
                _unitOfWork.GenericRepository<Appoinment>().Delete(appointment);
            }

            var user = _unitOfWork.GenericRepository<ApplicationUser>().GetAll()
                .FirstOrDefault(x => x.Id == id);
            _unitOfWork.GenericRepository<ApplicationUser>().Delete(user);
            _unitOfWork.Save();
        }
    }
}