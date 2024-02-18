using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Entity;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterDto, AppUser>();
            CreateMap<AppUser, CustomerDto>();
            CreateMap<CustomerUpdateDto, AppUser>();
            CreateMap<Product, Category>();
            CreateMap<Product, ProductDto>();
            CreateMap<CategoryDto, ProductDto>();
            CreateMap<Product, ProductDto>(); // Map Product entity to ProductDto
            CreateMap<CartItem, CartItemDto>();
            CreateMap<Category, CategoryDto>(); // Map Category entity to CategoryDto
            CreateMap<ShoppingCart, ShoppingCartDto>();
            CreateMap<ShoppingCartDto, CartItemDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();
        }
    }
}