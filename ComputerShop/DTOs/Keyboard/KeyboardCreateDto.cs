using System.ComponentModel.DataAnnotations;

namespace ComputerShop.DTOs.Keyboard
{
    public class KeyboardCreateDto
    {
        [Required]
        public string Name { get; set; }

        public string SwitchType { get; set; }
        public bool IsWireless { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }
    }
}
