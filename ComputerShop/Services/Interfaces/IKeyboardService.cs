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
    }

}
