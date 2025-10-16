using System.ComponentModel.DataAnnotations;

namespace ComputerShop.Models
{
    using System.ComponentModel.DataAnnotations;

    namespace ComputerShop.Models
    {
        public class User
        {
            public int Id { get; set; }

            [Required]
            public string FullName { get; set; }

            [Required, EmailAddress]
            public string Email { get; set; }

            [Required]
            public string PasswordHash { get; set; }

            public string Role { get; set; } = "User"; // "User" yoki "Admin"

            public ICollection<Cart> Carts { get; set; }
            public ICollection<Wishlist> Wishlists { get; set; }
        }
    }

}
