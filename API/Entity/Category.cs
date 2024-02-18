using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entity
{
    public class Category
    {
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    // Navigation property for products in this category
    public ICollection<Product> Products { get; set; }
    }
}