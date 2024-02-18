using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entity
{
    public class Review
    {
    public int ReviewId { get; set; }
    public int ProductId { get; set; } // Foreign key for Product
    public Product Product { get; set; } // Navigation property
    public int UserId { get; set; } // Foreign key for User
    public AppUser User { get; set; } // Navigation property
    public string Title { get; set; }
    public string Body { get; set; }
    public int Rating { get; set; } // Rating out of 5 stars
    public DateTime DatePosted { get; set; }
    }
}