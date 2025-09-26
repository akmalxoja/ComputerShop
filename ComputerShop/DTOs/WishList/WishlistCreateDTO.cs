using System.ComponentModel.DataAnnotations;

namespace ComputerShop.DTOs.WishList
{
    public class WishlistCreateDTO
    {
        [Required]
        public int UserId { get; set; }

        public int? ComputerId { get; set; }
        public int? KeyboardId { get; set; }
    }

    public class WishlistReadDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int? ComputerId { get; set; }
        public int? KeyboardId { get; set; }
    }

}
