

namespace API.DTO
{
    public class UserDto
    {
        public int Id {get; set;}
        public string Username { get; set; }

        public string Token { get; set; }

        public ShoppingCartDto ShoppingCart { get; set; }
    }
}