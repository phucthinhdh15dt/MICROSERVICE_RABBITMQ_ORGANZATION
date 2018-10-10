using PlusTechPlusSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlusTechPlusSystem.Repository.IRepository
{
    public interface IProfileSystem
    {
        ProfileSystem getFindID_ProfileSystem(string id);
        bool Create_ProfileSystem(ProfileSystem _ProfileSystem);
        bool Edit_ProfileSystem(string id, ProfileSystem _ProfileSystem);
        bool Delete_ProfileSystem(string id);
        IEnumerable<ProfileSystem> PagingAndFilter_ProfileSystem(int page, int pageNow, string sortExpression);
        IEnumerable<ProfileSystem> PagingAndCondition_ProfileSystem(string filter, int page, int pageNow, string sortExpression);
        int CountAndFilter_ProfileSystem(string filter);
    }
}
