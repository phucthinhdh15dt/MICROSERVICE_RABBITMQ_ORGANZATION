using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlusTechPlusSystem.Proccessor.AddEditRemoveCommon
{
    public static class Genaral_Add_Edit_Remove<T> where T : class
    {
        public static bool Add_ObjInDatabase(T obj, DbContext db)
        {
            try
            {
                db.Add<T>(obj);
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public static bool Edit_ObjInDatabase(T obj, string id, DbContext db)
        {
                try
                {
                    db.Update<T>(obj);
                    db.SaveChanges();
                    db.Dispose();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
        }
        public static bool Remove_ObjInDatabase(string id, DbContext db)
        {
            try
            {

                T find = db.Find<T>(id);
                if (find != null)
                {
                    db.Remove<T>(find);
                    db.SaveChanges();
                    db.Dispose();
                    return true;
                }
                return false;

            }
            catch (Exception)
            {
                return false;
            }

        }
        }
    }
