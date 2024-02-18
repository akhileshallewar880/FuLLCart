using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entity;

namespace API.DTO
{
    public class ShoppingCartDto
    {
    public int ShoppingCartId { get; set; }
    public int UserId { get; set; } // Foreign key for User
    public List<CartItemDto> CartItems { get; set; }
    }
}