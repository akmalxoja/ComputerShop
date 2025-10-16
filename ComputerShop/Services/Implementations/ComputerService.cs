using ComputerShop.Data;
using ComputerShop.DTOs.Computer;
using ComputerShop.Models;
using ComputerShop.Services.Implementations;
using Microsoft.EntityFrameworkCore;

namespace ComputerShop.Services.Implementation
{
    public class ComputerService : IComputerService
    {
        private readonly AppDbContext _context;

        public ComputerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Computer>> GetAllAsync()
        {
            return await _context.Computers.ToListAsync();
        }

        public async Task<Computer?> GetByIdAsync(int id)
        {
            return await _context.Computers.FindAsync(id);
        }

        public async Task<Computer> CreateAsync(ComputerCreateDto dto)
        {
            var computer = new Computer
            {
                Name = dto.Name,
                Cpu = dto.Cpu,
                Gpu = dto.Gpu,
                Ram =dto.Ram,
                Storage = dto.Storage,
                Price = dto.Price,
                ImageUrl = dto.ImageUrl
            };

            _context.Computers.Add(computer);
            await _context.SaveChangesAsync();
            return computer;
        }

        public async Task<Computer?> UpdateAsync(int id, ComputerUpdateDto dto)
        {
            var computer = await _context.Computers.FindAsync(id);
            if (computer == null) return null;

            computer.Name = dto.Name ?? computer.Name;
            computer.Cpu = dto.Cpu ?? computer.Cpu;
            computer.Gpu = dto.Gpu ?? computer.Gpu;
            computer.Ram = dto.Ram ?? computer.Ram;
            computer.Storage = dto.Storage ?? computer.Storage;
            computer.Price = dto.Price ?? computer.Price;
            computer.ImageUrl = dto.ImageUrl ?? computer.ImageUrl;

            await _context.SaveChangesAsync();
            return computer;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var computer = await _context.Computers.FindAsync(id);
            if (computer == null) return false;

            _context.Computers.Remove(computer);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<List<Computer>> FilterAsync(ComputerFilterDto filterDto)
        {
            var query = _context.Computers.AsQueryable();

            if (!string.IsNullOrEmpty(filterDto.Cpu))
                query = query.Where(c => c.Cpu == filterDto.Cpu);

            if (!string.IsNullOrEmpty(filterDto.Gpu))
                query = query.Where(c => c.Gpu == filterDto.Gpu);

        /*    if (!string.IsNullOrEmpty(filterDto.Motherboard))
                query = query.Where(c => c.Motherboard == filterDto.Motherboard);

            if (!string.IsNullOrEmpty(filterDto.Ssd))
                query = query.Where(c => c.Ssd == filterDto.Ssd);

            if (!string.IsNullOrEmpty(filterDto.Hdd))
                query = query.Where(c => c.Hdd == filterDto.Hdd);*/

            if (filterDto.MinRam.HasValue)
                query = query.Where(c => c.Ram >= filterDto.MinRam.Value);

            if (filterDto.MaxRam.HasValue)
                query = query.Where(c => c.Ram <= filterDto.MaxRam.Value);

            if (filterDto.MinPrice.HasValue)
                query = query.Where(c => c.Price >= filterDto.MinPrice.Value);

            if (filterDto.MaxPrice.HasValue)
                query = query.Where(c => c.Price <= filterDto.MaxPrice.Value);

            return await query.ToListAsync();
        }


        public async Task<List<string>> GetAvailableCpusAsync()
        {
            return await _context.Computers
                .Select(c => c.Cpu)
                .Where(c => c != null)
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<string>> GetAvailableGpusAsync()
        {
            return await _context.Computers
                .Select(c => c.Gpu)
                .Where(c => c != null)
                .Distinct()
                .ToListAsync();
        }

        public IEnumerable<Computer> SearchComputers(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return _context.Computers.ToList();

            return _context.Computers
                .Where(c => c.Name.ToLower().Contains(keyword.ToLower()))
                .ToList();
        }
    }
}
