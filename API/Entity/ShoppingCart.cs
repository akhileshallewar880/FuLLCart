using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entity
{
    public class ShoppingCart
    {
        
    public int ShoppingCartId { get; set; }
    public int UserId { get; set; } // Foreign key for User
    public AppUser User { get; set; } // Navigation property

    public List<CartItem> CartItems { get; set; }
    }
}