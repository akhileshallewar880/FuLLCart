using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entity;

namespace API.DTO
{
    public class OrderDto
    {
        public string ShippingAddress { get; set; }

        public decimal TotalPrice { get; set; }

        public int ProductId { get; set; } // Foreign key for Product
                                           // public Product Product { get; set; } // Navigation property
        public int Quantity { get; set; }

        public List<ProductDto> Products {get; set;}
        public decimal UnitPrice { get; set; }

    }
}