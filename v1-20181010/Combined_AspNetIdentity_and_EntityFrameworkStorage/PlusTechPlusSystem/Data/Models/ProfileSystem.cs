using System;
using System.Collections.Generic;

namespace PlusTechPlusSystem.Data.Models
{
    public partial class ProfileSystem
    {
        public int Id { get; set; }
        public string IdProfile { get; set; }
        public string NameProfile { get; set; }
        public string Role { get; set; }
        public string KeyOgranzition { get; set; }
        public string KeySystem { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Ogranzition KeyOgranzitionNavigation { get; set; }
    }
}
