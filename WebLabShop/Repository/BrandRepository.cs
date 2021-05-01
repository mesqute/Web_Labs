using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLabShop.DbContexts;
using WebLabShop.Interfaces;
using WebLabShop.Models;

namespace WebLabShop.Mocks
{
    public class BrandRepository : IRepository<Brands>
    {
        private WebDbContexts db;

        public BrandRepository(WebDbContexts db)
        {
            this.db = db;
        }

        public void Add(Brands obj)
        {
            throw new NotImplementedException();
        }

        public Brands GetLastObj()
        {
            throw new NotImplementedException();
        }

        public Brands GetObj(int id)
        {
            return db.Brands.Find(id);
        }

        public IEnumerable<Brands> GetObjList()
        {
            return db.Brands;
        }

        public IEnumerable<Brands> GetObjList(string item)
        {
            throw new NotImplementedException();
        }
    }
}
