using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerWithAspIdAndEF.ModelsInput
{
    public class ResgisterAccount
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public string DisplayName { get; set; }
        public string KeyOrganID { get; set; }
        public string keySystemID { get; set; }
    }
}
