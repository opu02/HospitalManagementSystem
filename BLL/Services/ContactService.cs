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
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteContact(int id)
        {
            var model = _unitOfWork.GenericRepository<Contact>().GetById(id);
            if (model != null)
            {
                _unitOfWork.GenericRepository<Contact>().Delete(model);
                _unitOfWork.Save();
            }
        }

        public PagedResult<ContactViewModel> GetAll(int pageNumber, int pageSize)
        {
            int totalCount = 0;
            List<ContactViewModel> vmList = new List<ContactViewModel>();

            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Contact>().GetAll(includeProperties: "Hospital")
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Contact>().GetAll().Count();

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }

            return new PagedResult<ContactViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

       
        public ContactViewModel GetContactById(int ContactId)
        {
            var model = _unitOfWork.GenericRepository<Contact>().GetById(ContactId);
            if (model == null) return null;
            return new ContactViewModel(model);
        }

        
        public ContactViewModel GetRoomById(int ContactId)
        {
            return GetContactById(ContactId);
        }

        public void InsertContact(ContactViewModel Contact)
        {
            
            var model = Contact.ConvertViewModel(Contact);
            _unitOfWork.GenericRepository<Contact>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateContact(ContactViewModel Contact)
        {
            var ModelById = _unitOfWork.GenericRepository<Contact>().GetById(Contact.Id);
            if (ModelById != null)
            {
                ModelById.Phone = Contact.Phone;
                ModelById.Email = Contact.Email;
                ModelById.HospitalId = Contact.HospitalInfoId;

                _unitOfWork.GenericRepository<Contact>().Update(ModelById);
                _unitOfWork.Save();
            }
        }

        private List<ContactViewModel> ConvertModelToViewModelList(List<Contact> modelList)
        {
            return modelList.Select(x => new ContactViewModel(x)).ToList();
        }
    }
}