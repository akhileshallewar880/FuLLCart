using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class CartItemDto
    {
        public int CartItemId { get; set; }

        public int ShoppingCartId {get; set;}

        public string productName {get; set;}

        public string ProductCategory {get; set;}

        public decimal productPrice {get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}