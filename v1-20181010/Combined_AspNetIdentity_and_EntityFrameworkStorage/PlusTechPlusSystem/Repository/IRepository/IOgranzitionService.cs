using PlusTechPlusSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlusTechPlusSystem.Repository.IRepository
{
    public interface IOgranzitionService
    {
        OgranzitionService getFindID_OgranzitionService(string id);
        bool Create_OgranzitionService(OgranzitionService _OgranzitionService);
        bool Edit_OgranzitionService(string id, OgranzitionService _OgranzitionService);
        bool Delete_OgranzitionService(string id);
        IEnumerable<OgranzitionService> PagingAndFilter_OgranzitionService(int page, int pageNow, string sortExpression);
        IEnumerable<OgranzitionService> PagingAndCondition_OgranzitionService(string filter, int page, int pageNow, string sortExpression);
        int CountAndFilter_OgranzitionService(string filter);

    }
}
