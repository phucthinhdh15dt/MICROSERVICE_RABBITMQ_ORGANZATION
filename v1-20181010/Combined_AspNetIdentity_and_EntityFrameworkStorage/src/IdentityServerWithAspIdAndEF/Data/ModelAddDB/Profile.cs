using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerWithAspIdAndEF.Controller
{
    public class Profile
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public Account Identity { get; set; }  // navigation property
        public string Email { get; set; }
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
