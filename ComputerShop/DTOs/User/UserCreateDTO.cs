using System.ComponentModel.DataAnnotations;

namespace ComputerShop.DTOs.User
{
    public class UserCreateDTO
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; } // UserCreate da PasswordHash emas, oddiy password olinadi
    }
}
