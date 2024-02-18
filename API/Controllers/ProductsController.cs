using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Entity;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IProductRepository productRepository1;

        private readonly DataContext dataContext1;
        private readonly IMapper mapper1;
        public ProductsController(IProductRepository productRepository, IMapper mapper, DataContext dataContext)
        {
            productRepository1 = productRepository;
            mapper1 = mapper;
            dataContext1 = dataContext;
        }

        [HttpGet] //api/products - get all products

        public async Task<ActionResult<PagedList<ProductDto>>> GetProducts([FromQuery] UserParams userParams)
        {
            var products = await productRepository1.GetProductsAsync(userParams);
            Response.AddPaginationHeader(new PaginationHeader(
                    products.CurrentPage,
                    products.PageSize,
                    products.TotalCount,
                    products.TotalPages
                ));

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            return await productRepository1.GetProductByIdAsync(id);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await productRepository1.GetCategoriesAsync();
            return Ok(categories);
        }


        [HttpGet("category/{id}")]
        public async Task<ActionResult<PagedList<ProductDto>>> GetProductsByCategory(int id,[FromQuery] UserParams userParams)
        {
            var products = await productRepository1.GetProductsByCategoryId(id, userParams);

            Response.AddPaginationHeader(new PaginationHeader(
                products.CurrentPage,
                products.PageSize,
                products.TotalCount,
                products.TotalPages
            ));

            return Ok(products);
        }


    }
}