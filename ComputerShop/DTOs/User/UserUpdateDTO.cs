using System.ComponentModel.DataAnnotations;

namespace ComputerShop.DTOs.User
{
    public class UserUpdateDTO
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
