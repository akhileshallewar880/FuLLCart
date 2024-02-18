using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entity;

namespace API.Interfaces
{
    public interface IShopingCartRepository
    {
            Task<ShoppingCart> GetByIdAsync(int id);
            Task AddAsync(ShoppingCart entity);
            Task UpdateAsync(ShoppingCart entity);
            Task DeleteAsync(ShoppingCart entity);
    }

    
}