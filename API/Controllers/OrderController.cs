using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.DTO;
using API.Entity;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OrderController : BaseApiController
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;

        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;


        public OrderController(IOrderRepository orderRepository, ICartItemRepository cartItemRepository,
        IUserRepository userRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> PlaceOrder()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userRepository.GetUserByUsernameAsync(username);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Ensure shopping cart is initialized
            if (user.ShoppingCart == null)
            {
                return Ok("Shopping cart is empty.");
            }

            // Retrieve cart items associated with the customer's shopping cart
            // Map the ShoppingCart entity to a ShoppingCartDto object

            var shoppingCartDto = _mapper.Map<ShoppingCartDto>(user.ShoppingCart);

            if (shoppingCartDto.CartItems == null)
            {
                return BadRequest("Cart is empty.");
            }

            var orderInit = new Order();

            // Create an order for each cart item
            var orders = new List<OrderItem>();
            foreach (var cartItem in shoppingCartDto.CartItems)
            {
                var orderItem = new OrderItem
                {
                    OrderId = orderInit.OrderId,
                    ProductName = cartItem.productName,
                    ProductCategory = cartItem.ProductCategory,
                    ProductPrice = cartItem.productPrice,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity
                };

                orders.Add(orderItem);
            
            }

            // Add orders to the database
            await _orderRepository.AddOrderItemAsync(orders);

            // Return success response
            return Ok("Order placed successfully.");
        }

    }
}