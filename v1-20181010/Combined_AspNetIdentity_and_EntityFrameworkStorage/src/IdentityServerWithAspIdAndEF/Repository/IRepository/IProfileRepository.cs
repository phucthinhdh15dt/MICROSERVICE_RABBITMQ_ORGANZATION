using IdentityServerWithAspIdAndEF.Controller;
namespace IdentityServerWithAspIdAndEF.Repository.IRepository
{
    public interface IProfileRepository
    {
        bool EditProfile(string username, Profile editprofile);
        Profile GetProfileByUserName(string userName);
    }
}
