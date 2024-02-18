using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entity;

namespace API.Interfaces
{
    public interface IOrderRepository
     {
        Task AddOrderItemAsync(List<OrderItem> orderItems);

        Task<bool> IsOrderTableEmptyAsync();
        Task AddOrdersAsync(List<Order> orders);
        Task UpdateExistingOrdersAsync(List<Order> newOrders);

        // Define other methods for interacting with orders as needed
    }
}