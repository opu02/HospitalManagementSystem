using BLL.Utilities;
using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public interface IContactService
    {
        PagedResult<ContactViewModel> GetAll(int pageNumber, int pageSize);
        ContactViewModel GetRoomById(int ContactId);
        void UpdateContact(ContactViewModel contact);
        void InsertContact(ContactViewModel contact);
        void DeleteContact(int id);
        ContactViewModel GetContactById(int id);
    }
}
