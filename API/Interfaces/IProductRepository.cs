using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Entity;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces
{
    public interface IProductRepository
    {
        void Update(Product product);

        Task<bool> SaveAllAsync();

        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<Product> GetProductByIdAsync(int id);

        Task<PagedList<ProductDto>> GetProductsByCategoryId(int categoryId, UserParams userParams);

        Task<PagedList<ProductDto>> GetProductsAsync(UserParams userParams);

        Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}