using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLabShop.Models
{
    public class Order
    {
        public long Id { get; set; }
        public string City { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<OrderedProduct> OrderedProducts { get; set; }

    }
}
