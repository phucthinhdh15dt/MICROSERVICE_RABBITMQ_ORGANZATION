using CatalogOrgantication.Data.ModelRabbitJson;
using CatalogOrgantication.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogOrgantication.CommunicationReponsitory
{
    public static class OgranzitionCommunicationReponsitory
    {
       private static CatalogOgranzitionForPropTechPlusContext catalog = new CatalogOgranzitionForPropTechPlusContext();
        private static bool findById(string id)
        {
            CatalogOgranzition a = catalog.CatalogOgranzition.Where(s => s.IdOgranzition == id).FirstOrDefault();
            if (a != null)
            {
                return false;
            }

            return true;
        }
        public static bool CreateCatalogOgranzition(Ogranzition ogranzition)
        {
                if (findById(ogranzition.IdOgranzition))
                {
                    Console.WriteLine("-----------------find");
                    CatalogOgranzition catalogOgranzition = new CatalogOgranzition
                    {
                        IdOgranzition = ogranzition.IdOgranzition,
                        NameOgranzition = ogranzition.NameOgranzition
                    };
                    Console.WriteLine("-----------------chuan bi save");
                    catalog.CatalogOgranzition.Add(catalogOgranzition);
                    catalog.SaveChanges();
                   
                    Console.WriteLine("-----------------fish");
                
                return true;
            }
            else
            {
                return false;
            }
           
        }
    }
}
