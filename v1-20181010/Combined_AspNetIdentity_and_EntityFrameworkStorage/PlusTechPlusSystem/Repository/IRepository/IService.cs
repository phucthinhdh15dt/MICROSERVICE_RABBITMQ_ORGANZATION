using PlusTechPlusSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlusTechPlusSystem.Repository.IRepository
{
    public interface IService
    {
        Service getFindID_Service(string id);
        bool Create_Service(Service _Service);
        bool Edit_Service(string id, Service _Service);
        bool Delete_Service(string id);
        IEnumerable<Service> PagingAndFilter_Service(int page, int pageNow, string sortExpression);
        IEnumerable<Service> PagingAndCondition_Service(string filter, int page, int pageNow, string sortExpression);
        int CountAndFilter_Service(string filter);
    }
}
