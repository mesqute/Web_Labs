using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLabShop.Models;

namespace WebLabShop.DbContexts
{
    public class WebDbContexts : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<OrderedProduct> OrderedProduct { get; set; }


        public WebDbContexts(DbContextOptions<WebDbContexts> options) : base(options)
        { }
    }
}
