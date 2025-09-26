namespace ComputerShop.Services.Implementations
{
    using ComputerShop.Data;
    using ComputerShop.DTOs.Keyboard;
    using ComputerShop.Models;
    using ComputerShop.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;


    public class KeyboardService : IKeyboardService
    {
        private readonly AppDbContext _context;

        public KeyboardService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Keyboard>> GetAllAsync()
        {
            return await _context.Keyboards.ToListAsync();
        }

        public async Task<Keyboard?> GetByIdAsync(int id)
        {
            return await _context.Keyboards.FindAsync(id);
        }

        public async Task<Keyboard> CreateAsync(KeyboardCreateDto dto)
        {
            var keyboard = new Keyboard
            {
                Name = dto.Name,
                SwitchType = dto.SwitchType,
                IsWireless = dto.IsWireless,
                Price = dto.Price,
                ImageUrl = dto.ImageUrl
            };

            _context.Keyboards.Add(keyboard);
            await _context.SaveChangesAsync();
            return keyboard;
        }

        public async Task<Keyboard?> UpdateAsync(int id, KeyboardUpdateDto dto)
        {
            var keyboard = await _context.Keyboards.FindAsync(id);
            if (keyboard == null) return null;

            keyboard.Name = dto.Name ?? keyboard.Name;
            keyboard.SwitchType = dto.SwitchType ?? keyboard.SwitchType;
            keyboard.IsWireless = dto.IsWireless ?? keyboard.IsWireless;
            keyboard.Price = dto.Price ?? keyboard.Price;
            keyboard.ImageUrl = dto.ImageUrl ?? keyboard.ImageUrl;

            await _context.SaveChangesAsync();
            return keyboard;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var keyboard = await _context.Keyboards.FindAsync(id);
            if (keyboard == null) return false;

            _context.Keyboards.Remove(keyboard);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
