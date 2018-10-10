using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryRepository.Reponsitory
{
    public interface IReponsitoryGeneral<T> where T : class
    {
        bool Add_Obj(T obj);
        bool Edit_Obj(T obj);
        bool Remove_Obj(string id);
    }
}
