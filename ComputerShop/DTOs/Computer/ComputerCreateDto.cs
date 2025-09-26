namespace ComputerShop.DTOs.Computer
{
    public class ComputerCreateDto
    {
        public string? Name { get; set; }
        public string? Cpu { get; set; }
        public string? Gpu { get; set; }
        public int Ram { get; set; }
        public int Storage { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
