namespace ComputerShop.DTOs.Keyboard
{
    public class KeyboardUpdateDto
    {
        public string? Name { get; set; }
        public string? SwitchType { get; set; }
        public bool? IsWireless { get; set; }
        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }
    }
}
