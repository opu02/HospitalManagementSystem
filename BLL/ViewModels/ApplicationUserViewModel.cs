using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModels
{
    public class ApplicationUserViewModel
    {
        public string Id { get; set; }

        public List<ApplicationUser> Doctors { get; set; } = new List<ApplicationUser>();

      public string name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

      public string City { get; set; }

      public Gender Gender { get; set; }

      public bool IsDoctor { get; set; }
      public string Specialist { get; set; }
        public string PictureUri { get; set; }



        public ApplicationUserViewModel()
        {

        }
        
        public ApplicationUserViewModel(ApplicationUser user)
        {
            Id = user.Id;
            name = user.name;
            City = user.City;
            Gender = user.Gender;
            IsDoctor = user.IsDoctor;
            Specialist = user.Specialist;
            UserName = user.UserName;
            Email = user.Email;
            PictureUri = user.PictureUri;
        }


            public ApplicationUser ConvertViewModelToModel(ApplicationUserViewModel user)
            {
            return new ApplicationUser
            {
                name = user.name,
                City = user.City,
                Gender = user.Gender,
                IsDoctor = user.IsDoctor,
                Specialist = user.Specialist,
                Email = user.Email,
                UserName = user.UserName
            };
        }
        public List<ApplicationUser> Doctor { get; set; } = new List<ApplicationUser>();   
    }
}
