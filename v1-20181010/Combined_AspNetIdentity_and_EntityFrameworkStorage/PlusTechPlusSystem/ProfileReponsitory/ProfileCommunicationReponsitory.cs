using PlusTechPlusSystem.Communication;
using PlusTechPlusSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlusTechPlusSystem.ProfileReponsitory
{
    public static class ProfileCommunicationReponsitory
    {
        private static PlusTechPlusSystemContext _context = new PlusTechPlusSystemContext();
        public static void CreateCatalogOgranzition(ProfileIdentityServer ProfileIdentityServer)
        {
            try
            {
                _context.ProfileSystem.Add(
                    new ProfileSystem
                    {
                        IdProfile = Guid.NewGuid()+"",
                        Address= ProfileIdentityServer.Address,
                        Email= ProfileIdentityServer.Email,
                        BirthDay = ProfileIdentityServer.BirthDay,
                        FirstName= ProfileIdentityServer.FirstName,
                        LastName= ProfileIdentityServer.LastName
                    }
                    );
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
