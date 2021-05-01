using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLabShop.DbContexts;
using WebLabShop.Interfaces;
using WebLabShop.Models;

namespace WebLabShop.Mocks
{
    public class ProductRepository : IRepository<Product>
    {
        private WebDbContexts db;

        public ProductRepository(WebDbContexts db)
        {
            this.db = db;
            foreach (Product product in db.Product)
            {
                product.Brand = db.Brands.Find(product.BrandId);
            }
        }

        public void Add(Product obj)
        {
            throw new NotImplementedException();
        }

        public Product GetLastObj()
        {
            throw new NotImplementedException();
        }

        public Product GetObj(int id)
        {
            return db.Product.Find(id);
        }

        public IEnumerable<Product> GetObjList()
        {
            return db.Product;
        }

        public IEnumerable<Product> GetObjList(string item)
        {
            return db.Product.Where(p => p.Brand.Name == item);
        }

    }
}
