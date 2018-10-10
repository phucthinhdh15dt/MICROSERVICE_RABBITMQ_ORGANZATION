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
    public class ImplOgranzitionService : IOgranzitionService
    {
        private PlusTechPlusSystemContext _context = new PlusTechPlusSystemContext();
        public int CountAndFilter_OgranzitionService(string filter)
        {
            var qry = _context.OgranzitionService.AsNoTracking()
                       .AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                return qry.Where(
                    p => p.PaymentDate.Equals(filter)
                    ).Count();
            }
            else
            {
                return qry.Count();
            }
        }
        public bool Create_OgranzitionService(OgranzitionService _OgranzitionService)
        {
            return Genaral_Add_Edit_Remove<OgranzitionService>.Add_ObjInDatabase(_OgranzitionService, _context);
        }
        public bool Delete_OgranzitionService(string id)
        {
            return Genaral_Add_Edit_Remove<OgranzitionService>.Remove_ObjInDatabase(id, _context);
        }
        public bool Edit_OgranzitionService(string id, OgranzitionService _OgranzitionService)
        {
            var findId_OgranzitionService = _context.OgranzitionService.Find(id);
            if (findId_OgranzitionService != null)
            {
                findId_OgranzitionService.LicenseAvailable = _OgranzitionService.LicenseAvailable;
                findId_OgranzitionService.LincenseAmount = _OgranzitionService.LincenseAmount;
                _context.SaveChanges();
                return true;
            }
            else
            {

                return false;
            }
        }
        public OgranzitionService getFindID_OgranzitionService(string id)
        {
            return _context.OgranzitionService.Find(id);
        }
        public IEnumerable<OgranzitionService> PagingAndCondition_OgranzitionService(string filter, int page, int pageNow, string sortExpression)
        {
            var qry = _context.OgranzitionService.AsNoTracking()
               .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                qry = qry.Where(
                    p => p.PaymentDate.Equals(filter)
                );
            }

            var model = PagingList.Create(
                                         qry, page, pageNow, sortExpression, sortExpression);

            model.RouteValue = new RouteValueDictionary {
                        { "filter", filter}
                    };

            return model;
        }
        public IEnumerable<OgranzitionService> PagingAndFilter_OgranzitionService(int page, int pageNow, string sortExpression)
        {
            var list = _context.OgranzitionService.AsNoTracking();
            var model = PagingList.Create(
                                    list, page, pageNow, sortExpression, sortExpression);
            return model;
        }
    }
    }

