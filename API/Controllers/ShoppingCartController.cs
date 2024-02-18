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
    public class ShoppingCartController : BaseApiController
    {
        private readonly ICartItemRepository cartItemRepository1;

        private readonly IUserRepository userRepository1;

        private readonly IShopingCartRepository shopingCartRepository1;

        private readonly IProductRepository productRepository1;

        private readonly IMapper mapper1;

        public ShoppingCartController(ICartItemRepository cartItemRepository, IProductRepository productRepository,
        IUserRepository userRepository, IShopingCartRepository shopingCartRepository, IMapper mapper)
        {
            cartItemRepository1 = cartItemRepository;
            userRepository1 = userRepository;
            shopingCartRepository1 = shopingCartRepository;
            productRepository1 = productRepository;
            mapper1 = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int customerId, int productId, int quantity)
        {
            // Retrieve customer information
            var customer = await userRepository1.GetUserByIdAsync(customerId);

            // Check if customer exists
            if (customer == null)
            {
                return NotFound("Customer not found.");
            }



            // Retrieve product information
            var product = await productRepository1.GetProductByIdAsync(productId);

            // Check if product exists
            if (product == null)
            {
                return NotFound("Product not found.");
            }

            // Ensure cart items collection is initialized
            if (customer.ShoppingCart.CartItems == null)
            {
                customer.ShoppingCart.CartItems = new List<CartItem>();
            }

            // Check if the product is already in the cart
            var existingCartItem = customer.ShoppingCart.CartItems.FirstOrDefault(item => item.ProductId == productId);

            if (existingCartItem != null)
            {
                // Update the quantity of the existing cart item
                existingCartItem.Quantity += quantity;
                await cartItemRepository1.UpdateAsync(existingCartItem);
            }
            else
            {
                // Create a new cart item and add it to the cart
                var newCartItem = new CartItem { ShoppingCartId = customer.ShoppingCart.ShoppingCartId, ProductId = productId, Quantity = quantity };
                customer.ShoppingCart.CartItems.Add(newCartItem);

                // Add the new cart item to the database
                await cartItemRepository1.AddAsync(newCartItem);
            }

            // Save changes to the customer (including the shopping cart)
            userRepository1.Update(customer);

            return Ok();
        }


        [HttpDelete("removeFromCart")]
        public async Task<IActionResult> RemoveFromCart(int customerId, int cartItemId)
        {
            // Retrieve customer information
            var customer = await userRepository1.GetUserByIdAsync(customerId);

            // Check if customer exists
            if (customer == null)
            {
                return NotFound("Customer not found.");
            }

            // Ensure shopping cart is initialized
            if (customer.ShoppingCart == null)
            {
                return NotFound("Shopping cart not found.");
            }

            // Retrieve the cart item to remove
            var cartItemToRemove = customer.ShoppingCart.CartItems.FirstOrDefault(item => item.CartItemId == cartItemId);

            // Check if the cart item exists
            if (cartItemToRemove == null)
            {
                return NotFound("Cart item not found.");
            }

            // Remove the cart item from the customer's shopping cart
            customer.ShoppingCart.CartItems.Remove(cartItemToRemove);

            // Delete the cart item from the database
            await cartItemRepository1.DeleteAsync(cartItemToRemove);

            // Save changes to the customer (including the shopping cart)
            userRepository1.Update(customer);

            return Ok();
        }

        [HttpGet("cartItems/{customerId}")]
        public async Task<IActionResult> GetCartItemsByCustomerId(int customerId)
        {
            // Retrieve customer information
            var customer = await userRepository1.GetUserByIdAsync(customerId);

            // Check if customer exists
            if (customer == null)
            {
                return NotFound("Customer not found.");
            }

            // Ensure shopping cart is initialized
            if (customer.ShoppingCart == null)
            {
                return Ok("Shopping cart is empty.");
            }

            // Retrieve cart items associated with the customer's shopping cart
            // Map the ShoppingCart entity to a ShoppingCartDto object

            var shoppingCartDto = mapper1.Map<ShoppingCartDto>(customer.ShoppingCart);

            foreach (var cartItemDto in shoppingCartDto.CartItems)
            {   
                var product = await productRepository1.GetProductByIdAsync(cartItemDto.ProductId);
                if (product != null)
                {
                    cartItemDto.productName = product.Name;
                    cartItemDto.productPrice = product.Price;
                }
            }

            return Ok(shoppingCartDto);

        }



    }
}