using BLL.Utilities;
using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public interface IApplicationUserService
    {
        PagedResult<ApplicationUserViewModel> GetAll(int PageNumber, int PageSize);

        PagedResult<ApplicationUserViewModel> GetAllDoctor(int PageNumber, int PageSize);

        PagedResult<ApplicationUserViewModel> GetAllPatient(int PageNumber, int PageSize);

        PagedResult<ApplicationUserViewModel> SearchDoctor(int PageNumber, int PageSize, string Spicility = null);

        IEnumerable<ApplicationUserViewModel> GetAllDoctors();

        ApplicationUserViewModel GetById(string id);
        void Update(ApplicationUserViewModel vm);
        void Delete(string id);

    }
}
