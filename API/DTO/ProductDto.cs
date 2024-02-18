using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entity;

namespace API.DTO
{
    public class ProductDto
    {
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int UnitPrice { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; } // Foreign key for Category

    public CategoryDto Category { get; set; }
    }
}