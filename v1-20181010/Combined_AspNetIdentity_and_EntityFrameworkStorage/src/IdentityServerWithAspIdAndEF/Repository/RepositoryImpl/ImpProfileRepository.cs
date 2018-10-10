using IdentityServerWithAspIdAndEF.Controller;
using IdentityServerWithAspIdAndEF.Data;
using IdentityServerWithAspIdAndEF.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace IdentityServerWithAspIdAndEF.Repository.RepositoryImpl
{
    public class ImpProfileRepository : IProfileRepository
    {
        ApplicationDbContext _appDbContext =new ApplicationDbContext();
        public bool EditProfile(string username,Profile editprofile)
        {
            Console.WriteLine(_appDbContext.Profile.ToList());
            Profile profile=_appDbContext.Profile.SingleOrDefault(r => r.Email.Equals(username));
            
            if (profile != null)
            {
                try
                {
                    Console.WriteLine(profile.Email+"11111111111111111");
                    _appDbContext.Profile.Update(editprofile);
                    return true;
                }
                catch (Exception)
                {
                    Console.WriteLine(profile.Email + "11111111111111111");
                    return false;
                    
                }
            }
            Console.WriteLine(profile.Email + "11111111111111111");
            return false;
        }

        public Profile GetProfileByUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return null;
            return _appDbContext.Profile.Where(email => email.Email.Equals(userName)).FirstOrDefault();
        }
    }
}
