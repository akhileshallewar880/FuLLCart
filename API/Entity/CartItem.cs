using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entity
{
    public class CartItem
    {
    public int CartItemId { get; set; }
    public int ShoppingCartId { get; set; } // Foreign key for ShoppingCart
    public ShoppingCart ShoppingCart { get; set; } // Navigation property
    public int ProductId { get; set; } // Foreign key for Product
    public Product Product { get; set; } // Navigation property
    public int Quantity { get; set; }
    }
}