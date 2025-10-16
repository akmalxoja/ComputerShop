using ComputerShop.DTOs.Computer;
using ComputerShop.DTOs.Keyboard;
using ComputerShop.Models;

namespace ComputerShop.Services.Interfaces
{
    public interface IKeyboardService
    {
        Task<List<Keyboard>> GetAllAsync();
        Task<Keyboard?> GetByIdAsync(int id);
        Task<Keyboard> CreateAsync(KeyboardCreateDto dto);
        Task<Keyboard?> UpdateAsync(int id, KeyboardUpdateDto dto);
        Task<bool> DeleteAsync(int id);

        Task<List<Keyboard>> FilterAsync(KeyboardFilterDto keyboardFilterDto);

        Task<List<string>> GetAvailableSwitchTypesAsync();
        Task<List<bool>> GetAvailableWirelessOptionsAsync();

        IEnumerable<Keyboard> SearchKeyboards(string keyword);
    }

}
