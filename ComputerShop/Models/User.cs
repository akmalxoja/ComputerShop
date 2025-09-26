using System.ComponentModel.DataAnnotations;

namespace ComputerShop.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        // Navigatsiyalar (foydalanuvchining savati va wishlisti bo‘lishi mumkin)
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }
    }
}
