using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLabShop.Models
{
    public class OrderedProduct
    {
        public long Id { get; set; }
        public int Count { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
