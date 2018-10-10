using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerWithAspIdAndEF.Controller
{
    public class Account : IdentityUser
    {
        // Extended Properties
        public Boolean Active { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public string role_id { get; set; }
        public string org_id { get; set; }
        public string KeyOrganID { get; set; }
        public string keySystemID { get; set; }
    }
}
