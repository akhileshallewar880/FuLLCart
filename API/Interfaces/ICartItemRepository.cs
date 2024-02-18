using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entity;

namespace API.Interfaces
{
    public interface ICartItemRepository
    {
        Task<CartItem> GetByIdAsync(int id);

        Task AddAsync(CartItem item);

        Task AddOrdersAsync(CartItem entity);

        Task UpdateAsync(CartItem entity);

        Task DeleteAsync(CartItem entity);
    }
}