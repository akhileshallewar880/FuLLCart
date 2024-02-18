using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entity;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ShoppingCartRepository : IShopingCartRepository
    {
        private readonly DataContext _dbContext;

        public ShoppingCartRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ShoppingCart> GetByIdAsync(int id)
        {
            return await _dbContext.Set<ShoppingCart>().FindAsync(id);
        }

        public async Task AddAsync(ShoppingCart entity)
        {
            await _dbContext.Set<ShoppingCart>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ShoppingCart entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ShoppingCart entity)
        {
            _dbContext.Set<ShoppingCart>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

    }
}