namespace ComputerShop.DTOs.Computer
{
    public class ComputerFilterDto
    {
        public string? Cpu { get; set; }
        public string? Gpu { get; set; }
        public int? MinRam { get; set; }
        public int? MaxRam { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? Motherboard { get; set; }
        public string? Ssd { get; set; }
        public string? Hdd { get; set; }
    }

}
