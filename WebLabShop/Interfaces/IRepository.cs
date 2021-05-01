using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLabShop.Models;

namespace WebLabShop.Interfaces
{
    interface IRepository<T>
        where T: class
    {

        IEnumerable<T> GetObjList();
        IEnumerable<T> GetObjList(string item);
        T GetObj(int id);
        T GetLastObj();
        void Add(T obj);
    }
}
