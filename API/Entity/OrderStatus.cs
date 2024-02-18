using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entity
{
    public enum OrderStatus
    {
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled
    }
}