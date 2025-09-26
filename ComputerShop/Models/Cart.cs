namespace ComputerShop.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        // Bu savatga Computer yoki Keyboard qo‘shiladi
        public int? ComputerId { get; set; }
        public Computer Computer { get; set; }

        public int? KeyboardId { get; set; }
        public Keyboard Keyboard { get; set; }

        public int Quantity { get; set; }
    }
}
