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
    public class ImplProfileSystem : IProfileSystem
    {
        private PlusTechPlusSystemContext _context = new PlusTechPlusSystemContext();
        public int CountAndFilter_ProfileSystem(string filter)
        {
            var qry = _context.ProfileSystem.AsNoTracking()
                       .AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                return qry.Where(
                    p => p.Email.Contains(filter) ||
                         p.Address.Contains(filter) ||
                         p.FirstName.Contains(filter) ||
                         p.LastName.Contains(filter) ||
                         p.KeyOgranzition.Contains(filter) ||
                         p.KeySystem.Contains(filter)
                    ).Count();
            }
            else
            {
                return qry.Count();
            }
        }
        public bool Create_ProfileSystem(ProfileSystem _ProfileSystem)
        {
            return Genaral_Add_Edit_Remove<ProfileSystem>.Add_ObjInDatabase(_ProfileSystem, _context);
        }
        public bool Delete_ProfileSystem(string id)
        {
            return Genaral_Add_Edit_Remove<ProfileSystem>.Remove_ObjInDatabase(id, _context);
        }
        public bool Edit_ProfileSystem(string id, ProfileSystem _ProfileSystem)
        {
            try
            {
                var findId_ProfileSystem = _context.ProfileSystem.Find(id);
                Console.WriteLine(findId_ProfileSystem.Email+"---------");
                if (findId_ProfileSystem != null)
                {
                    findId_ProfileSystem.PhoneNumber = _ProfileSystem.PhoneNumber;
                    findId_ProfileSystem.NameProfile = _ProfileSystem.NameProfile;
                    findId_ProfileSystem.LastName = _ProfileSystem.LastName;
                    findId_ProfileSystem.BirthDay = _ProfileSystem.BirthDay;
                    findId_ProfileSystem.Role = _ProfileSystem.Role;
                    findId_ProfileSystem.KeyOgranzition = _ProfileSystem.KeyOgranzition;
                    findId_ProfileSystem.Address = _ProfileSystem.Address;
                    _context.SaveChanges();
                    _context.Dispose();
                    return true;
                }
                else
                {

                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
           
        }
        public ProfileSystem getFindID_ProfileSystem(string id)
        {
            return _context.ProfileSystem.Find(id);
        }
        public IEnumerable<ProfileSystem> PagingAndCondition_ProfileSystem(string filter, int page, int pageNow, string sortExpression)
        {
            var qry = _context.ProfileSystem.AsNoTracking()
               .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                qry = qry.Where(
                    p => p.Email.Contains(filter) ||
                         p.Address.Contains(filter) ||
                         p.FirstName.Contains(filter) ||
                         p.LastName.Contains(filter) ||
                         p.KeyOgranzition.Contains(filter) ||
                         p.KeySystem.Contains(filter) 
                        

                );
            }

            var model = PagingList.Create(
                                         qry, page, pageNow, sortExpression, sortExpression);

            model.RouteValue = new RouteValueDictionary {
                        { "filter", filter}
                    };

            return model;
        }
        public IEnumerable<ProfileSystem> PagingAndFilter_ProfileSystem(int page, int pageNow, string sortExpression)
        {
            var list = _context.ProfileSystem.AsNoTracking();
            var model = PagingList.Create(
                                    list, page, pageNow, sortExpression, sortExpression);
            return model;
        }
    }
}
