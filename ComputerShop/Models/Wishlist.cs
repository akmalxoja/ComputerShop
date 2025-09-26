namespace ComputerShop.Models
{
    public class Wishlist
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int? ComputerId { get; set; }
        public Computer Computer { get; set; }

        public int? KeyboardId { get; set; }
        public Keyboard Keyboard { get; set; }
    }
}
