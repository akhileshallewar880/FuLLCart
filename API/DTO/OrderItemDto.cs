using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}