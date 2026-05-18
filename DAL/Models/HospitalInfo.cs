using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class HospitalInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string City { get; set; } 
        public string PinCode { get; set; }
        public string Country { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public string? RoomNumber { get; set; }
        public string? Status { get; set; }
        public int HospitalId { get; set; }
    }
}
