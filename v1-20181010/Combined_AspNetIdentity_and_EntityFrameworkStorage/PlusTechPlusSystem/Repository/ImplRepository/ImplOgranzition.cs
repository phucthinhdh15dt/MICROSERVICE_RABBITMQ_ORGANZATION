using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using PlusTechPlusSystem.Data.Models;
using PlusTechPlusSystem.Proccessor.AddEditRemoveCommon;
using PlusTechPlusSystem.Repository.IRepository;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlusTechPlusSystem.Repository.ImplRepository
{
    public class ImplOgranzition : IOgranzition
    {
        private PlusTechPlusSystemContext _context = new PlusTechPlusSystemContext();
        public int CountAndFilter_Ogranzition(string filter)
        {
            var qry = _context.Ogranzition.AsNoTracking()
                       .AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                return qry.Where(
                    p => p.NameOgranzition.Contains(filter)
                    ).Count();
            }
            else
            {
                return qry.Count();
            }
        }
        public bool Create_Ogranzition(Ogranzition _Ogranzition)
        {
          return  Genaral_Add_Edit_Remove<Ogranzition>.Add_ObjInDatabase(_Ogranzition,_context);
        }
        public bool Delete_Ogranzition(string id)
        {
            return Genaral_Add_Edit_Remove<Ogranzition>.Remove_ObjInDatabase(id, _context);
        }
        public bool Edit_Ogranzition(string id, Ogranzition _Ogranzition)
        {
            var findId_Ogranzition = _context.Ogranzition.Find(id);
            if (findId_Ogranzition != null)
            {
                findId_Ogranzition.NameOgranzition = _Ogranzition.NameOgranzition;
                _context.SaveChanges();
                return true;
            }
            else
            {

                return false;
            }
        }
        public Ogranzition getFindID_Ogranzition(string id)
        {
            return _context.Ogranzition.Find(id);
        }
        public IEnumerable<Ogranzition> PagingAndCondition_Ogranzition(string filter, int page, int pageNow, string sortExpression)
        {
                    var qry = _context.Ogranzition.AsNoTracking()
                       .AsQueryable();

                    if (!string.IsNullOrWhiteSpace(filter))
                    {
                        qry = qry.Where(
                            p => p.NameOgranzition.Contains(filter)
                        );
                    }

                    var model =  PagingList.Create(
                                                 qry, page, pageNow, sortExpression, sortExpression);

                            model.RouteValue = new RouteValueDictionary {
                        { "filter", filter}
                    };

            return model;
        }
        public  IEnumerable<Ogranzition> PagingAndFilter_Ogranzition(int page, int pageNow, string sortExpression)
        {
            var qry = _context.Ogranzition.AsNoTracking()
                .AsQueryable();
            var model =  PagingList.Create(
                                    qry, page, pageNow, sortExpression, sortExpression);
            return model;
        }

       
    }
}
