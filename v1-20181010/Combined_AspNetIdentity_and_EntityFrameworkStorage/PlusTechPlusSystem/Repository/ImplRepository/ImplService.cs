using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using PlusTechPlusSystem.Data.Models;
using PlusTechPlusSystem.Proccessor.AddEditRemoveCommon;
using PlusTechPlusSystem.Repository.IRepository;
using ReflectionIT.Mvc.Paging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlusTechPlusSystem.Repository.ImplRepository
{
    public class ImplService : IService
    {
        private PlusTechPlusSystemContext _context = new PlusTechPlusSystemContext();
        public int CountAndFilter_Service(string filter)
        {
            var qry = _context.Service.AsNoTracking()
                       .AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                return qry.Where(
                    p => p.NameService.Contains(filter)
                    ).Count();
            }
            else
            {
                return qry.Count();
            }
        }
        public bool Create_Service(Service _Service)
        {
            return Genaral_Add_Edit_Remove<Service>.Add_ObjInDatabase(_Service, _context);
        }
        public bool Delete_Service(string id)
        {
            return Genaral_Add_Edit_Remove<Service>.Remove_ObjInDatabase(id, _context);
        }
        public bool Edit_Service(string id, Service _Service)
        {
            var findId_Service = _context.Service.Find(id);
            if (findId_Service != null)
            {
                findId_Service.NameService = _Service.NameService;
                _context.SaveChanges();
                return true;
            }
            else
            {

                return false;
            }
        }
        public Service getFindID_Service(string id)
        {
            return _context.Service.Find(id);
        }
        public IEnumerable<Service> PagingAndCondition_Service(string filter, int page, int pageNow, string sortExpression)
        {
            var qry = _context.Service.AsNoTracking()
               .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                qry = qry.Where(
                    p => p.NameService.Contains(filter)
                );
            }

            var model = PagingList.Create(
                                         qry, page, pageNow, sortExpression, sortExpression);

            model.RouteValue = new RouteValueDictionary {
                        { "filter", filter}
                    };

            return model;
        }
        public IEnumerable<Service> PagingAndFilter_Service(int page, int pageNow, string sortExpression)
        {
            var list = _context.Service.AsNoTracking();
            var model = PagingList.Create(
                                    list, page, pageNow, sortExpression, sortExpression);
            return model;
        }
    }
}
