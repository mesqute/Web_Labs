using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLabShop.DbContexts;
using WebLabShop.Interfaces;
using WebLabShop.Models;

namespace WebLabShop.Repository
{
    public class OrderedProductRepository : IRepository<OrderedProduct>
    {
        private WebDbContexts db;

        public OrderedProductRepository(WebDbContexts db)
        {
            this.db = db;

        }

        public void Add(OrderedProduct obj)
        {
            db.OrderedProduct.Add(obj);
            db.SaveChanges();
        }

        public OrderedProduct GetLastObj()
        {
            throw new NotImplementedException();
        }

        public OrderedProduct GetObj(int id)
        {
            return db.OrderedProduct.Find(id);
        }

        public IEnumerable<OrderedProduct> GetObjList()
        {
            return db.OrderedProduct;
        }

        public IEnumerable<OrderedProduct> GetObjList(string item)
        {
            throw new NotImplementedException();
        }
    }
}
