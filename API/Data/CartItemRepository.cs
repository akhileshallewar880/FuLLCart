using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entity;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CartItemRepository : ICartItemRepository
{
    private readonly DataContext _dbContext;

    public CartItemRepository(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CartItem> GetByIdAsync(int id)
    {
        return await _dbContext.Set<CartItem>().FindAsync(id);
    }

    
    public async Task AddAsync(CartItem entity)
    {
        await _dbContext.Set<CartItem>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(CartItem entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(CartItem entity)
    {
        _dbContext.Set<CartItem>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

        public Task AddOrdersAsync(CartItem entity)
        {
            throw new NotImplementedException();
        }
    }

}