using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Entity;
using API.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey key;

        // Constructor for TokenService class
        public TokenService(IConfiguration config)
        {
            // Initializing SymmetricSecurityKey with token key stored in configuration
            key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        // Method to create JWT token
        public string CreateToken(AppUser appUser)
        {
            // Creating claims for JWT token
            var claims = new List<Claim>
            {
                // Adding user's username as a claim
                new Claim(JwtRegisteredClaimNames.NameId, appUser.Username)
            };

            // Creating signing credentials using symmetric security key
            var creds = new SigningCredentials(this.key, SecurityAlgorithms.HmacSha512Signature);

            // Creating token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // Setting subject of token descriptor to claims identity
                Subject = new ClaimsIdentity(claims),

                // Setting token expiration time (7 days from now)
                Expires = DateTime.Now.AddDays(7),

                // Setting signing credentials
                SigningCredentials = creds
            };

            // Creating JWT token handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // Creating JWT token using token descriptor
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Writing JWT token to string
            return tokenHandler.WriteToken(token);
        }
    }
}
