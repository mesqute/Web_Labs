using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLabShop.DbContexts;
using WebLabShop.Interfaces;
using WebLabShop.Models;

namespace WebLabShop.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        private WebDbContexts db;

        public OrderRepository(WebDbContexts db)
        {
            foreach (Order order in db.Order)
            {
                order.OrderedProducts = db.OrderedProduct.Where(p => p.OrderId == order.Id).ToList();
            }
            this.db = db;

        }
        public Order GetObj(int id)
        {
            return db.Order.Find(id);
        }

        public IEnumerable<Order> GetObjList()
        {
            return db.Order;
        }
        public void Create(Order order)
        {
            db.Order.Add(order);
        }

        public IEnumerable<Order> GetObjList(string item)
        {
            throw new NotImplementedException();
        }

        public void Add(Order obj)
        {
            db.Order.Add(obj);
            db.SaveChanges();
        }

        public Order GetLastObj()
        {
            ;
            return db.Order.OrderBy(c => c.Id).Last();
        }
    }
}
