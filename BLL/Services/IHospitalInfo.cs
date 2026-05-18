using BLL.Utilities;
using BLL.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public interface IHospitalInfo
    {
        PagedResult<HospitalInfoViewModel> GetAll(int pageNumber, int pageSize);

        HospitalInfoViewModel GetHospitalById(int HospitalId);
        void UpdateHospitalInfo (HospitalInfoViewModel HospitalInfo);
        void InsertHospitalInfo (HospitalInfoViewModel HospitalInfo);
        void DeleteHospitalInfo (int id);
        IEnumerable GetAll();
    }
}

