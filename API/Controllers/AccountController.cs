using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Entity;
using API.Interfaces;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    // Controller responsible for handling account-related operations
    public class AccountController : BaseApiController
    {
        private readonly DataContext dataContext1; // Reference to the data context

        private readonly ITokenService tokenService1; // Reference to the token service

        private readonly IMapper mapper1; // Reference to the AutoMapper for object mapping

        // Constructor injecting necessary dependencies
        public AccountController(DataContext dataContext, ITokenService tokenService, IMapper mapper)
        {
            this.dataContext1 = dataContext;
            this.tokenService1 = tokenService;
            this.mapper1 = mapper;
        }

        // Endpoint for user registration
        [HttpPost("register")] // POST : api/account/register
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            // Checking if the provided username already exists in the database
            if (await UserExists(registerDto.Username)) 
                return BadRequest("Username already taken");

            // Mapping RegisterDto to AppUser using AutoMapper
            var user = mapper1.Map<AppUser>(registerDto);

            // Generating a new HMACSHA512 for password hashing
            using var hmac = new HMACSHA512();

            // Setting user properties
            user.Username = registerDto.Username.ToLower();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password));
            user.PasswordSalt = hmac.Key;
            user.ShoppingCart = new ShoppingCart();
            user.Order = new Order();

            // Adding the user to the database
            dataContext1.Users.Add(user);

            // Saving changes to the database
            await dataContext1.SaveChangesAsync();

            // Returning UserDto with username and JWT token
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Token = tokenService1.CreateToken(user),
            };
        }

        // Method to check if a user with the given username exists
        private async Task<bool> UserExists(string username)
        {
            return await dataContext1.Users.AnyAsync(x => x.Username == username.ToLower());
        }

        // Endpoint for user login
        [HttpPost("login")] // POST : api/account/login
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            // Finding the user with the provided username in the database
            var user = await dataContext1.Users
                .SingleOrDefaultAsync(x => x.Username == loginDto.Username.ToLower());

            // Returning Unauthorized if no user is found
            if (user == null) 
                return Unauthorized("Invalid Username");

            // Creating a new HMACSHA512 with the user's password salt
            using var hmac = new HMACSHA512(user.PasswordSalt);

            // Computing hash of the provided password
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            // Checking if the computed hash matches the stored password hash
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (user.PasswordHash[i] != computedHash[i]) 
                    return Unauthorized("Invalid Password");
            }

            // Returning UserDto with username and JWT token
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Token = tokenService1.CreateToken(user)
            };
        }
    }
}
