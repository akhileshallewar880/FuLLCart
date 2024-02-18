using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entity;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

       public async Task<bool> IsOrderTableEmptyAsync()
    {
        return !await _context.Orders.AnyAsync();
    }

    public async Task AddOrderItemAsync(List<OrderItem> orders)
    {
        await _context.OrderItems.AddRangeAsync(orders);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateExistingOrdersAsync(List<Order> newOrders)
    {
        foreach (var newOrder in newOrders)
        {
            var existingOrder = await _context.Orders.FindAsync(newOrder.OrderId);

            if (existingOrder != null)
            {
                existingOrder.Status = newOrder.Status;
                // Add logic to update other properties as needed

                await UpdateOrderItemsAsync(existingOrder, newOrder.OrderItems);
            }
        }

        await _context.SaveChangesAsync();
    }

    private async Task UpdateOrderItemsAsync(Order existingOrder, ICollection<OrderItem> newOrderItems)
    {
        // Assuming OrderItems are being replaced entirely with new items
        existingOrder.OrderItems.Clear();
        foreach (var newItem in newOrderItems)
        {
            existingOrder.OrderItems.Add(newItem);
        }
    }

        public Task AddOrdersAsync(List<Order> orders)
        {
            throw new NotImplementedException();
        }
    }

}