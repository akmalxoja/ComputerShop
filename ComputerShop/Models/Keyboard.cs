using System.ComponentModel.DataAnnotations;

namespace ComputerShop.Models
{
    public class Keyboard
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string SwitchType { get; set; }   // Mechanical / Membrane
        public bool IsWireless { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }
    }
}
