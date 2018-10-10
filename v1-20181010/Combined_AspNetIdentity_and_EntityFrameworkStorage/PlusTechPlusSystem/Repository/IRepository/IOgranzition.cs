using PlusTechPlusSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlusTechPlusSystem.Repository.IRepository
{
   public interface IOgranzition
    {
       
        Ogranzition getFindID_Ogranzition(string id);
        bool Create_Ogranzition(Ogranzition _Ogranzition);
        bool Edit_Ogranzition(string id,Ogranzition _Ogranzition);
        bool Delete_Ogranzition(string id);
        IEnumerable<Ogranzition> PagingAndFilter_Ogranzition(int page, int pageNow,string sortExpression);
        IEnumerable<Ogranzition> PagingAndCondition_Ogranzition(string filter, int page, int pageNow, string sortExpression);
        int CountAndFilter_Ogranzition(string filter);
    }
}
