using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Orderline
    {
        public long? Id { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public Orderline(long id, Order order, Product product, int quantity)
        {
            Id = id;
            Order = order;
            Product = product;
            Quantity = quantity;
        }

        public Orderline(Order order, Product product, int quantity)
        {
            Order = order;
            Product = product;
            Quantity = quantity;
        }
    }
}