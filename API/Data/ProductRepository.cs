using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Entity;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext dataContext1;
        private readonly IMapper mapper1;

        public ProductRepository(DataContext dataContext, IMapper mapper)
        {
            dataContext1 = dataContext;
            mapper1 = mapper;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await dataContext1.Products
                      
                      .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await dataContext1.Category.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await dataContext1.Products.FindAsync(id);
        }

        public async Task<PagedList<ProductDto>> GetProductsByCategoryId(int categoryId, UserParams userParams)
        {
            var query = dataContext1.Products
                .Where(p => p.CategoryId == categoryId)
                .ProjectTo<ProductDto>(mapper1.ConfigurationProvider)
                .AsQueryable();

            return await PagedList<ProductDto>.CreateAsync(query, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<PagedList<ProductDto>> GetProductsAsync(UserParams userParams)
        {
            var query = dataContext1.Products
                    .Include(p => p.Category)
                    .ProjectTo<ProductDto>(mapper1.ConfigurationProvider)
                    .AsNoTracking();

            return await PagedList<ProductDto>.CreateAsync(query, userParams.PageNumber, userParams.PageSize);
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }

         public async Task AddProductAsync(Product product)
    {
        // Implement logic to add a single product to the database
        // Example:
        await dataContext1.Products.AddAsync(product);
        await dataContext1.SaveChangesAsync();
    }
        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}