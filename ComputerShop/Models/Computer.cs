using System.ComponentModel.DataAnnotations;

namespace ComputerShop.Models
{
    public class Computer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpu { get; set; }
        public string Gpu { get; set; }
        public int Ram { get; set; }
        public int Storage { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
