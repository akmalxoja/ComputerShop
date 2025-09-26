using ComputerShop.DTOs.Computer;
using ComputerShop.Models;

namespace ComputerShop.Services.Implementations
{
    public interface IComputerService
    {
        Task<List<Computer>> GetAllAsync();
        Task<Computer?> GetByIdAsync(int id);
        Task<Computer> CreateAsync(ComputerCreateDto dto);
        Task<Computer?> UpdateAsync(int id, ComputerUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<Computer>> FilterAsync(ComputerFilterDto filterDto);


        // 🔹 Dropdown uchun variantlar
        Task<List<string>> GetAvailableCpusAsync();
        Task<List<string>> GetAvailableGpusAsync();
      /*  Task<List<string>> GetAvailableMotherboardsAsync();
        Task<List<string>> GetAvailableSsdsAsync();
        Task<List<string>> GetAvailableHddsAsync();*/
    }



}
