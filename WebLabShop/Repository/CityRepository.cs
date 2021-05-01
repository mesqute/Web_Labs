using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLabShop.DbContexts;
using WebLabShop.Interfaces;
using WebLabShop.Models;

namespace WebLabShop.Repository
{
    public class CityRepository : IRepository<City>
    {
        private WebDbContexts db;

        public CityRepository(WebDbContexts db)
        {
            this.db = db;
        }

        public void Add(City obj)
        {
            throw new NotImplementedException();
        }

        public City GetLastObj()
        {
            throw new NotImplementedException();
        }

        public City GetObj(int id)
        {
            return db.City.Find(id);
        }

        public IEnumerable<City> GetObjList()
        {
            return db.City;
        }

        public IEnumerable<City> GetObjList(string item)
        {
            throw new NotImplementedException();
        }
    }
}
