using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entity
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public string ProductName { get; set; }

        public string ProductCategory { get; set; }

        public decimal ProductPrice { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public Order Order { get; set; }

        // Foreign key for Order
        // public Order Order { get; set; } // Navigation property

    }
}