using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryRepository.Reponsitory
{
    public class ImplReponsitoryGeneral<T> : IReponsitoryGeneral<T> where T : class
    {

        public ImplReponsitoryGeneral()
        {

        }
        public bool Add_Obj(T obj)
        {
            throw new NotImplementedException();
        }

        public bool Edit_Obj(T obj)
        {
            throw new NotImplementedException();
        }

        public bool Remove_Obj(string id)
        {
            throw new NotImplementedException();
        }
    }
}
