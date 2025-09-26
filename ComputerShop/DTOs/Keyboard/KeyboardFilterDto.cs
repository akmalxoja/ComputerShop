namespace ComputerShop.DTOs.Keyboard
{
    public class KeyboardFilterDto
    {
        public string? SwitchType { get; set; }   // faqat Mechanical ni qidirish mumkin
        public bool? IsWireless { get; set; }     // true/false bo‘yicha filtrlash
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
