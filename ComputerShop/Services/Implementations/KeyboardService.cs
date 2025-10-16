namespace ComputerShop.Services.Implementations
{
    using ComputerShop.Data;
    using ComputerShop.DTOs.Keyboard;
    using ComputerShop.Models;
    using ComputerShop.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

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



    
        public async Task<List<Keyboard>> FilterAsync(KeyboardFilterDto filterDto)
        {
           
                var query = _context.Keyboards.AsQueryable();

                if (!string.IsNullOrEmpty(filterDto.SwitchType))
                    query = query.Where(k => k.SwitchType == filterDto.SwitchType);

            //if (!string.IsNullOrEmpty(filterDto.Brand))
            //    query = query.Where(k => k.Brand == filterDto.Brand);

                if (filterDto.IsWireless.HasValue)
                    query = query.Where(k => k.IsWireless == filterDto.IsWireless);

                if (filterDto.IsWireless.HasValue)
                        query = query.Where(k => k.IsWireless == filterDto.IsWireless.Value);

                if (filterDto.MinPrice.HasValue)
                    query = query.Where(k => k.Price >= filterDto.MinPrice.Value);

                if (filterDto.MaxPrice.HasValue)
                    query = query.Where(k => k.Price <= filterDto.MaxPrice.Value);

                //return await query.ToListAsync();
                return await query.ToListAsync();
            
        }


        public async Task<List<string>> GetAvailableSwitchTypesAsync()
        {
            return await _context.Keyboards
                .Select(k => k.SwitchType)
                .Distinct()
                .OrderBy(x => x)
                .ToListAsync();
        }

        public async Task<List<bool>> GetAvailableWirelessOptionsAsync()
        {
            return await _context.Keyboards
                .Select(k => k.IsWireless)
                .Distinct()
                .OrderBy(x => x)
                .ToListAsync();
        }

        public IEnumerable<Keyboard> SearchKeyboards(string keyword)
        {
             if (string.IsNullOrWhiteSpace(keyword))
                return _context.Keyboards.ToList();

            return _context.Keyboards
                .Where(c => c.Name.ToLower().Contains(keyword.ToLower()))
                .ToList();
        }
    }

}
