using System.ComponentModel.DataAnnotations;

namespace ComputerShop.DTOs.Cart
{
    public class CartCreateDTO
    {
        [Required]
        public int UserId { get; set; }

        public int? ComputerId { get; set; }
        public int? KeyboardId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }

    public class CartReadDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int? ComputerId { get; set; }
        public int? KeyboardId { get; set; }

        public int Quantity { get; set; }
    }

    public class CartUpdateDTO
    {
        [Required]
        public int Quantity { get; set; }
    }

}
